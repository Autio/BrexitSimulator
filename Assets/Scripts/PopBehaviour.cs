using UnityEngine;
using System.Collections;

public class PopBehaviour : MonoBehaviour {

	public GameObject[] images;
    public bool agitated = false;
    private float moveTick = 1.0f;

	private float standardSpeed = 30;
	public Color originalColor;
	public Color targetColor;
	public int popType;

	private float agitationCount;
	float agitationMultiplier = 1.0f;

    // Use this for initialization
	void Start () {
		//float value = Mathf.Lerp (0f, 1f, 0.3f);
		//this.transform.FindChild(images[popType].name).GetComponent<Renderer> ().material.SetColor ("_Albedo", targetColor);
	//	this.transform.FindChild(images[popType].name).GetComponent<SpriteRenderer> ().color = targetColor;
		agitationCount = Random.Range (2.0f, 90.0f);
	}
	
	// Update is called once per frame
	void Update () {

		moveTick -= Time.deltaTime;
		agitationCount -= Time.deltaTime;
	

		if (moveTick < 0)
		{
			moveTick = Random.Range (0.3f, 2.0f);
			BrownianMove (standardSpeed);

		}


		if (agitationCount < 0) {

			agitationCount = Random.Range (7.0f, 32.0f) * agitationMultiplier;
			agitationMultiplier *= 0.98f;
			Agitate ();

		}

        if(Input.GetKeyDown(KeyCode.C))
        {
            BrownianMove();
        }


		// increase risk factor


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

	public void Agitate()
	{
		agitated = true;
		this.transform.FindChild(images[popType].name).GetComponent<SpriteRenderer> ().color = targetColor;
	}

	public void Calm()
	{
		agitated = false;
		this.transform.FindChild(images[popType].name).GetComponent<SpriteRenderer> ().color = originalColor;
	}


	void OnMouseDown()
	{
		Debug.Log ("pop clicked");
		BrownianMove (60);
		Calm ();
	}
		

}
