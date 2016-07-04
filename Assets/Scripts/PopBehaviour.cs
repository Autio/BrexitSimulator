using UnityEngine;
using System.Collections;

public class PopBehaviour : MonoBehaviour {

	public GameObject[] images;
    public bool agitated = false;
    private float moveTick = 1.0f;

	private float standardSpeed = 30;
	public Color targetColor;

    // Use this for initialization
	void Start () {
		this.GetComponent<Renderer> ().material.SetColor ("_Albedo", targetColor);
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

	// move in a vector from mouse click to unit center
	public void DirectedMove(float speed = 30.0f)
	{
		Vector2 inputPos = Input.mousePosition;
		Vector2 thisPos = transform.position;
		GetComponent<Rigidbody2D>().AddForce((inputPos - thisPos) * speed);

	}

	void OnMouseDown()
	{
		Debug.Log ("pop clicked");
		BrownianMove (60);
	}
		

}
