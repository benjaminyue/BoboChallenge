using UnityEngine;
using System.Collections;

using ADInterstitialAd = UnityEngine.iOS.ADInterstitialAd;

public class interstatial : MonoBehaviour {
	
	private ADInterstitialAd fullscreenAd = null;
	
	void Start()
	{
		fullscreenAd = new ADInterstitialAd();
		ADInterstitialAd.onInterstitialWasLoaded  += OnFullscreenLoaded;
	}
	
	void OnFullscreenLoaded()
	{
		fullscreenAd.Show();
	}
}