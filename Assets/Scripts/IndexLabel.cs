using TMPro;
using UnityEngine;

namespace AddressablesSample
{
	public class IndexLabel : MonoBehaviour
	{
		public PrefabSwitcher Switcher;
		public TMP_Text Label;

		private void Awake()
		{
			Switcher.PrefabChanged += UpdateLabel;

			UpdateLabel();
		}

		private void OnDestroy()
		{
			Switcher.PrefabChanged -= UpdateLabel;
		}

		private void UpdateLabel()
		{
			Label.text = Switcher.Index.ToString();
		}
	}
}