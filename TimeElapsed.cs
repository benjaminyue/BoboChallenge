using UnityEngine;
using System.Collections;

public class TimeElapsed : MonoBehaviour {

	static float timer= 0f; // set duration time in seconds in the Inspector
	static float highScore = 0f;
	
	void Start(){
		GetComponent<GUIText>().fontSize = Screen.width/6;
		highScore = PlayerPrefs.GetFloat ("highScore", 0);
		timer = 0f;
	}

	void Update(){
		if (!GameObject.Find("PlayerBird").GetComponent<BirdMovement>().dead) {
				timer += Time.deltaTime;
		}
						
		if(timer>highScore){
			highScore = timer;
		}
		GetComponent<GUIText>().text = timer.ToString("F0"); 

	}

	void OnDestroy(){
		PlayerPrefs.SetFloat ("highScore", highScore);
		PlayerPrefs.SetFloat ("score", timer);
	}

}

	


