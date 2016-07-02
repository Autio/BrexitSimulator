﻿using UnityEngine;
using System.Collections;

public class PopBehaviour : MonoBehaviour {

    public bool agitated = false;
    private float moveTick = 1.0f;

	private float standardSpeed = 30;
    // Use this for initialization
	void Start () {
	        
	}
	
	// Update is called once per frame
	void Update () {

		moveTick -= Time.deltaTime;
		if (moveTick < 0)
		{
			moveTick = Random.Range (0.3f, 2.0f);
			BrownianMove (standardSpeed);

		}

        if(Input.GetKeyDown(KeyCode.C))
        {
            BrownianMove();
        }
	}

    // pulse in random direction
    public void BrownianMove(float speed = 30.0f)
    {
        Vector2 randomDir = new Vector2(Random.Range(-1.0f,1.0f), Random.Range(-1.0f,1.0f));
      

		GetComponent<Rigidbody2D>().AddForce(randomDir * speed);
        
		moveTick += Random.Range (0.1f, 0.2f);
    }

	void OnMouseDown()
	{
		Debug.Log ("pop clicked");
		BrownianMove (60);
	}
		
}