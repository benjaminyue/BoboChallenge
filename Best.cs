using UnityEngine;
using System.Collections;

public class Best : MonoBehaviour {

	// Use this for initialization
	void Start () {

		GetComponent<GUIText>().fontSize = Screen.width/10;
		GetComponent<GUIText>().text =  (PlayerPrefs.GetFloat ("highScore")).ToString("F0");
	}

}
