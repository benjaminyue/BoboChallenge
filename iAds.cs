using UnityEngine;
using System.Collections;

using iAds = UnityEngine.iOS.ADBannerView;

public class iAds : MonoBehaviour {
	
	private UnityEngine.iOS.ADBannerView banner = null;
	void Start()
	{
		banner = new UnityEngine.iOS.ADBannerView(UnityEngine.iOS.ADBannerView.Type.Banner, UnityEngine.iOS.ADBannerView.Layout.BottomCenter);
		UnityEngine.iOS.ADBannerView.onBannerWasClicked += OnBannerClicked;
		UnityEngine.iOS.ADBannerView.onBannerWasLoaded += OnBannerLoaded;
	}
	
	void OnBannerClicked()
	{
		Debug.Log("Clicked!\n");
	}
	
	void OnBannerLoaded()
	{
		Debug.Log("Loaded!\n");
		banner.visible = true;
	}
}