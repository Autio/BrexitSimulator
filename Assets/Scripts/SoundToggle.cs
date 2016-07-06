using UnityEngine;
using System.Collections;

public class SoundToggle : MonoBehaviour {

	private bool soundOn = true;
	public AudioSource music;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("Button pressed");
		if (soundOn) {
			music.Stop ();
			soundOn = false;
		} else {
			soundOn = true;
			music.Play ();
		}
	}
}
