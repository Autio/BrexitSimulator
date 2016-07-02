using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<GameObject> pops = new List<GameObject>();
	public GameObject s;
	public GameObject ni;

	public List<string> buttonTexts = new List<string>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			AgitateAllPops ();
		}
	}

	public void AgitateAllPops()
	{
		foreach (GameObject pop in pops) 
		{
			pop.GetComponent<PopBehaviour> ().BrownianMove (42);
		}

	}

	public void ButtonReaction()
	{
		AgitateAllPops ();
		// push parts away
		// push s
		s.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.5f, 0.5f), 1f) * Random.Range(80, 120));

		// push ni
		ni.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 0.0f), Random.Range(-0.4f, 0.4f)) * Random.Range(80, 120));
	}

}
