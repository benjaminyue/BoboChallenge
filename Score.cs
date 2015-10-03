using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<GUIText>().fontSize = Screen.width/10;
		GetComponent<GUIText>().text =  (PlayerPrefs.GetFloat ("score")).ToString("F0");
	}

}
