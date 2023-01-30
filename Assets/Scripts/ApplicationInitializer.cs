using UnityEngine;
using UnityEngine.AddressableAssets;

namespace AddressablesSample
{
	public static class ApplicationInitializer
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void Initialize()
		{
			Addressables.LoadSceneAsync("SampleScene");
		}
	}
}