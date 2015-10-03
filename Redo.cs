using UnityEngine;
using System.Collections;

public class Redo : MonoBehaviour {

	public AudioClip button;
	private UnityEngine.iOS.ADBannerView banner = null;

	private void OnMouseDown(){
		GetComponent<AudioSource>().PlayOneShot(button,5f);
		AutoFade.LoadLevel("Game" ,0.5f,0.5f,Color.white);
		/*banner = new UnityEngine.iOS.ADBannerView(UnityEngine.iOS.ADBannerView.Type.MediumRect, UnityEngine.iOS.ADBannerView.Layout.Top);
		UnityEngine.iOS.ADBannerView.onBannerWasClicked += OnBannerClicked;
		UnityEngine.iOS.ADBannerView.onBannerWasLoaded  += OnBannerLoaded;*/
	}



	/*void OnBannerClicked()
	{
		Debug.Log("Clicked!\n");
	}

	void OnBannerLoaded()
	{
		Debug.Log("Loaded!\n");
		banner.visible = true;
	}*/


}
