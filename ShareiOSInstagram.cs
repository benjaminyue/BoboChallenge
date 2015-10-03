using UnityEngine;
using System.Collections;

public class ShareiOSInstagram : MonoBehaviour 
{
	Texture2D _texture;
	RenderTexture _renderTexture;

	public AudioClip button;
	private void OnMouseDown(){
		GetComponent<AudioSource>().PlayOneShot(button,5f);
		StartCoroutine(PostToInstagram());
	}
	
	byte[] GrabScreenshot()
	{
		if(_texture != null)
			Destroy(_texture);
		
		// Initialize and render
		_renderTexture = new RenderTexture(Screen.width, Screen.height, 24);
		Camera.main.targetTexture = _renderTexture;
		Camera.main.Render();
		RenderTexture.active = _renderTexture;
		
		// Read pixels
		_texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		_texture.ReadPixels(new Rect(0,0,Screen.width,Screen.height), 0, 0);
		
		// Clean up
		Camera.main.targetTexture = null;
		RenderTexture.active = null;
		DestroyImmediate(_renderTexture);
		
		return _texture.EncodeToPNG();
	}
	
	IEnumerator PostToInstagram()
	{
		yield return new WaitForEndOfFrame();
		int score = (int)PlayerPrefs.GetFloat ("score");

		ShareiOSInstagramFunction.PostToInstagram("WHOA...Just Got " + score + " in Bobo's Challenge #Bobos  http://itunes.com/apps/BenjaminYue/BobosChallenge", GrabScreenshot());
	}
}