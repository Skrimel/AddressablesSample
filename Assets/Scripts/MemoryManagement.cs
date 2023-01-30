using System;
using UnityEngine;
using UnityEngine.UI;

namespace AddressablesSample
{
	public class MemoryManagement : MonoBehaviour
	{
		[SerializeField]
		private Button _unloadResourcesButton;
		[SerializeField]
		private Button _garbageCollectionButton;

		private void Awake()
		{
			_unloadResourcesButton.onClick.AddListener(UnloadResources);
			_garbageCollectionButton.onClick.AddListener(GarbageCollection);
		}

		private void UnloadResources()
		{
			Resources.UnloadUnusedAssets();
		}

		private void GarbageCollection()
		{
			GC.Collect();
		}
	}
}