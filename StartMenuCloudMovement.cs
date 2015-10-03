using UnityEngine;
using System.Collections;

public class StartMenuCloudMovement : MonoBehaviour {


	// Update is called once per frame
	void FixedUpdate () {
		transform.position = transform.position + Vector3.left * 0.1f;
	}
}
