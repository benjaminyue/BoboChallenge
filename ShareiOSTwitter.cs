using UnityEngine;
using System.Collections;

public class ShareiOSTwitter : MonoBehaviour {

	public AudioClip button;
	private void OnMouseDown(){
		GetComponent<AudioSource>().PlayOneShot (button, 5f);
		int score = (int)PlayerPrefs.GetFloat ("score");
		ShareToTwitter ("WHOA...Just Got " + score + " in Bobo's Challenge #Bobos  http://itunes.com/apps/BenjaminYue/BobosChallenge");
	}

	private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
	private const string TWEET_LANGUAGE = "en"; 
	
	void ShareToTwitter (string textToDisplay)
	{
		// Application.OpenURL("twitter:///user?screen_name=username");
		Application.OpenURL("twitter://post?message=WHAO!%20...%20finally%20got%20a%20high%20score%20in%20Bobo's%20Challenge%20%23Bobos%20bit%2ely%2f1I5jTZL");
	
	}



}
