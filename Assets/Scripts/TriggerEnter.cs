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
			gc.GetComponent<GameController> ().SpawnText ("Scotland joins the Nordic countries");
		}

		if (collider.tag == "irishWin") {
			gc.GetComponent<GameController> ().SpawnText ("Northern Ireland and the Republic of Ireland unite");
		}



	}
}
