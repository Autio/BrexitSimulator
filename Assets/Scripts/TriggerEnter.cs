using UnityEngine;
using System.Collections;

public class TriggerEnter : MonoBehaviour {
	public GameObject gc;

	// Use this for initialization
	void Start () {
		gc = GameObject.Find ("GameController");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.tag == "nordicWin") {
			Debug.Log ("Norwin");
		}

		if (collider.tag == "irishWin") {
			Debug.Log ("Norwin");
		}



	}
}
