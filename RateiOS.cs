using UnityEngine;
using System.Collections;

public class RateiOS : MonoBehaviour {

	public AudioClip button;
	private void OnMouseDown(){
		GetComponent<AudioSource>().PlayOneShot (button, 5f);
		Application.OpenURL("http://appstore.com/benjaminyue");
	}

}
