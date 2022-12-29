using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace AddressablesSample
{
	public class PrefabSwitcher : MonoBehaviour
	{
		public List<AssetReferenceT<GameObject>> References;
		public Transform Pivot;

		private AsyncOperationHandle<GameObject> _handle;
		private bool _isLoading;

		private GameObject _prefabInstance;
		public int Index { get; private set; }

		public event Action PrefabChanged;

		private AssetReferenceT<GameObject> CurrentReference => References[Index];

		private async void Awake()
		{
			await SetPrefabByIndex(0);
		}

		private void OnDestroy()
		{
			UnloadCurrentPrefab();
		}

		public async Task<bool> ShiftPrefabIndex(int delta)
		{
			try
			{
				var index = Index;

				index += delta + References.Count;
				index %= References.Count;

				return await SetPrefabByIndex(index);
			}
			catch (Exception e)
			{
				Debug.LogError(e);
				throw;
			}
		}

		private async Task<bool> SetPrefabByIndex(int index)
		{
			if (_isLoading)
			{
				return false;
			}

			_isLoading = true;

			UnloadCurrentPrefab();

			Index = index;

			_handle = Addressables.LoadAssetAsync<GameObject>(CurrentReference);
			var prefab = await _handle.Task;
			_prefabInstance = Instantiate(prefab, Pivot);

			_isLoading = false;

			PrefabChanged?.Invoke();

			return true;
		}

		private void UnloadCurrentPrefab()
		{
			if (_prefabInstance != null)
			{
				Destroy(_prefabInstance);
				_prefabInstance = null;

				Addressables.Release(_handle);
				_handle = default;
			}
		}
	}
}