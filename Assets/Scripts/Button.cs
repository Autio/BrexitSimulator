using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button : MonoBehaviour {

	private GameController gc;
	private GameObject buttonText;
	public List<string> buttonTexts = new List<string>();


	// Use this for initialization
	void Start () {
		gc = GameObject.Find ("GameController").GetComponent<GameController> ();
		buttonText = GameObject.Find("ButtonText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("Button pressed");
		gc.ButtonReaction();

		buttonTexts [0] = "hello \n hello";
		// change text
		buttonText.GetComponent<TextMesh>().text = buttonTexts[Random.Range(0, buttonTexts.Count)];
	}


}
