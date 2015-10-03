using UnityEngine;
using System.Collections;

public class ProductionTimer : MonoBehaviour {

	float timeLeft = 1f;
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if(timeLeft<0){
			AutoFade.LoadLevel("start menu" ,1,1,Color.black);  
		}	
	}
}
