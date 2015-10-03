using UnityEngine;
using System.Collections;

public class TipSelector : MonoBehaviour {
	
	// Use this for initialization
	
	public GUIText referencetotext;
	
	void Start () {
		GetComponent<GUIText>().fontSize = Screen.width/30;
		int which = Random.Range (1,7);
		if(which ==1)
			referencetotext.text = "Tip: Always be flicking";
		if (which == 2)
			referencetotext.text = "Tip: Fast flick = fast movement";
		if (which == 3)
			referencetotext.text = "Tip: To move a little = flick slow over small distance";
		if (which == 4)
			referencetotext.text = "Tip: Flick with index finger";
		if (which == 5)
			referencetotext.text = "Tip: Movement is sensitive to flick speed";
		if (which == 6)
			referencetotext.text = "Tip: Only flick up and down, not sideways";
		
	}
	
}