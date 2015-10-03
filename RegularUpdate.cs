using UnityEngine;
using System.Collections;

public class RegularUpdate : MonoBehaviour {

	// Update is called once per frame

	public AudioClip click;
	void OnMouseDown () {
		if (Input.GetMouseButtonDown(0)) {
			GetComponent<AudioSource>().PlayOneShot(click,7f);
			AutoFade.LoadLevel("Game" ,0.7f,0.7f,Color.black);  
		}
	}
	
	
	
}
