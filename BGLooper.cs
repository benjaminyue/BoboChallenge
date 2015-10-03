using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 4;

	float max = 6f;
	float min = 3f;

	void Start(){
		GameObject[] array = GameObject.FindGameObjectsWithTag ("Pipe");

		foreach(GameObject pipe in array){
			Vector3 pos = pipe.transform.position;
			pos.y = Random.Range (min,max);
			pipe.transform.position = pos;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered " + collider.name);

		if (collider.name == "LongCloud") {
						float widthOfBGObject = ((BoxCollider2D)collider).size.x;

						Vector3 pos = collider.transform.position;

						pos.x += widthOfBGObject * numBGPanels;


						collider.transform.position = pos;
				} 
		if(collider.name == "bgSky1"){
			float widthOfBGObject = ((BoxCollider2D)collider).size.x;
			
			Vector3 pos = collider.transform.position;
			
			pos.x += widthOfBGObject * 14;

			
			collider.transform.position = pos;

		}

		if(collider.name == "1"){
			float widthOfBGObject = ((BoxCollider2D)collider).size.x;
			
			Vector3 pos = collider.transform.position;
			
			pos.x += widthOfBGObject * 4;

			if (collider.tag == "Pipe") {
				pos.y = Random.Range (min, max);
			}
			
			collider.transform.position = pos;
			
		}


	}
}
