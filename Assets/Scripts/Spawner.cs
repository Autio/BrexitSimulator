using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject spawnable;
	public int spawnCount = 20;
	public float radius = 1;
	public int spriteType = 0;
	private GameController gc;


	// Use this for initialization
	void Start () {
		gc = GameObject.Find ("GameController").GetComponent<GameController> ();

		for (int i = 0; i < spawnCount; i++)
		{
			Vector2 pos = new Vector2 (this.transform.position.x + Random.Range (-radius, radius), this.transform.position.y + Random.Range (-radius, radius));
			GameObject s = (GameObject)Instantiate (spawnable, pos, Quaternion.identity);
			gc.pops.Add (s);
			s.transform.SetParent (this.transform);
			if (spriteType >= 0 && spriteType < 4) {
				s.GetComponent<PopBehaviour> ().images [spriteType].SetActive (true);
			}

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


}
