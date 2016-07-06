using UnityEngine;
using System.Collections;

public class BackgroundClick : MonoBehaviour {
	public GameObject explode;
	private float forceModifier = 50;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Vector3 v = new Vector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint (Input.mousePosition).y, 0);

		GameObject go = (GameObject)Instantiate (explode,v, Quaternion.identity);
		Collider2D[] c = Physics2D.OverlapCircleAll (new Vector2 (v.x, v.y),1.0f);
	
		foreach (Collider2D o in c) {
	// hack
			if (o.gameObject.name != "Button") {
				try {
					o.gameObject.GetComponent<Rigidbody2D> ().AddForce ((o.transform.position - v) * forceModifier);
				} catch {

				}
			}
		}
		Destroy (go, 1.5f);
	}
}
