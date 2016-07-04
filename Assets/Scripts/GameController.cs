using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public List<GameObject> pops = new List<GameObject>();
	public GameObject s;
	public GameObject ni;
	public GameObject ew;
	public GameObject textSpawn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			AgitateAllPops ();
			SpawnText ("helloooo");
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
		s.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.1f, 0.7f), Random.Range(-0.2f, 0.5f)) * Random.Range(150, 250));

		// push ni
		ni.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 0.0f), Random.Range(-0.4f, 0.4f)) * Random.Range(80, 120));

		// shrink ew
		ew.transform.localScale *= .98f;
	}


	void SpawnText(string text)
	{
		Instantiate (textSpawn, new Vector3 (0, 0, -3), Quaternion.identity);
		textSpawn.GetComponent<TextMesh> ().text = text;

	}


}
