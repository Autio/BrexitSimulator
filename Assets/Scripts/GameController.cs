using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public List<GameObject> pops = new List<GameObject>();
	public GameObject s;
	public GameObject ni;
	public GameObject ew;
	public GameObject textSpawn;
	public int popCount;
	public float checkAgitationCount = 0.5f;
	public GameObject button;
	public GameObject daycounter;
	public int dayCount;
	private float dayTick = 2.0f;
	private bool ticking = true;
	private bool ended = false;

	// Use this for initialization
	void Start () {
		button = GameObject.Find ("Button");
		daycounter = GameObject.Find ("Daycounter");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.B)) {
			AgitateAllPops ();
			SpawnText ("A Brexit Simulator");
		}

		if (Input.GetKeyDown (KeyCode.R) || Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene ("Main");
		}


		dayTick -= Time.deltaTime;
		if (ticking) {
			if (dayTick < 0) {
				dayCount += 1;
				daycounter.GetComponent<TextMesh> ().text = dayCount.ToString ();
				dayTick = 2.0f;
			}
		}

		checkAgitationCount -= Time.deltaTime;
		if (checkAgitationCount < 0) {
			int agitationCounter = 0;
			// see if more than 50% are agitated, if so reset half of the agitated ones
			foreach (GameObject pop in pops) {
				if (pop.GetComponent<PopBehaviour> ().agitated) {
					agitationCounter += 1;
				}
			}
			if (agitationCounter > popCount / 2) {
				// trigger button
				ButtonReaction();
				button.GetComponent<Button> ().RefreshText ();

			}
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
		// calm about half of the agitated units
		foreach (GameObject pop in pops) {
			if (pop.GetComponent<PopBehaviour> ().agitated) {
				if (Random.Range (0.0f, 1.0f) < 0.5f) {
					pop.GetComponent<PopBehaviour> ().Calm ();
				}
			}
		}
		button.GetComponent<Button> ().CreateHeartBeat ();
		// push parts away
		// push s
		s.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-0.1f, 0.7f), Random.Range(-0.2f, 0.3f)) * Random.Range(150, 250));

		// push ni
		ni.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 0.0f), Random.Range(-0.4f, 0.4f)) * Random.Range(80, 120));

		// shrink ew
		ew.transform.localScale *= .98f;

		// win condition
		if (ew.transform.localScale.x < 1f && !ended) {

			SpawnText ("England gains independence");
			ended = true;
		}
	}


	public void SpawnText(string text)
	{
		GameObject t = (GameObject)Instantiate (textSpawn, new Vector3 (0, 0, -3), Quaternion.identity);
		t.GetComponent<TextMesh> ().text = text;
		Destroy (t.gameObject, 4.0f);
		if (ticking) {
			daycounter.GetComponent<TextMesh> ().fontSize *= 4;
			daycounter.transform.position = new Vector3 (daycounter.transform.position.x, daycounter.transform.position.y + 0.5f, daycounter.transform.position.z);
		}
		ticking = false;

	}


}
