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

		buttonTexts.Add("Increase\nausterity");
		buttonTexts.Add("Bomb\nMiddle East");
		buttonTexts.Add("Demonise\nopposition");
		buttonTexts.Add("Erode\nNHS");
		buttonTexts.Add("Cut\ndisability\nbenefits");
		buttonTexts.Add("Blame\nimmigrants");
		buttonTexts.Add("Blame\nthe EU");
		buttonTexts.Add("Privatise\nschools");
		buttonTexts.Add("Privatise\nRoyal Mail");
		buttonTexts.Add("Bail out\nbanks");
		buttonTexts.Add("Loosen\nregulation");
		buttonTexts.Add("Contracts\nto friends");
		buttonTexts.Add("Close\nlibraries");
		buttonTexts.Add("Redefine\nchild poverty");
		buttonTexts.Add("Demonise\nIslam");
		buttonTexts.Add("Stoke\npetty\nnationalism");
		buttonTexts.Add("Suffocate\nhouse\nbuilding");
		buttonTexts.Add("Scrap\ngreen\nsubsidies");
		buttonTexts.Add("Boost\nLondon");
		buttonTexts.Add("Privatise\ncouncil\nhouses");
		buttonTexts.Add("Demonise\nHuman\nRights\nAct");
		buttonTexts.Add("Demonise\nAsylum\nSeekers");


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("Button pressed");
		gc.ButtonReaction();


		// change text
		buttonText.GetComponent<TextMesh>().text = buttonTexts[Random.Range(0, buttonTexts.Count)];
	}


}
