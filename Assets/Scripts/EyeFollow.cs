using UnityEngine;
using System.Collections;

public class EyeFollow : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 current = transform.position;
		Vector2 targetPos = target.transform.position;
		Vector2 direction = targetPos - current;
		float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg + 90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


	}


}
