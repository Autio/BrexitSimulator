using UnityEngine;
using System.Collections;

public class TextExpander : MonoBehaviour {

	public float speed = 3.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale += new Vector3(Time.deltaTime * speed, Time.deltaTime * speed, Time.deltaTime * speed);
	}
}
