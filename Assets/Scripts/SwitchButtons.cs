using UnityEngine;
using UnityEngine.UI;

namespace AddressablesSample
{
	public class SwitchButtons : MonoBehaviour
	{
		public Button MoveToNextButton;
		public Button MoveToPreviousButton;
		public PrefabSwitcher Switcher;

		private void Awake()
		{
			MoveToNextButton.onClick.AddListener(MoveToNext);
			MoveToPreviousButton.onClick.AddListener(MoveToPrevious);
		}

		private void OnDestroy()
		{
			MoveToNextButton.onClick.RemoveListener(MoveToNext);
			MoveToPreviousButton.onClick.RemoveListener(MoveToPrevious);
		}

		private void MoveToNext()
		{
			_ = Switcher.ShiftPrefabIndex(1);
		}

		private void MoveToPrevious()
		{
			_ = Switcher.ShiftPrefabIndex(-1);
		}
	}
}