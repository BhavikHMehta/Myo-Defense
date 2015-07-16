using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingClouds : MonoBehaviour {

	public Rigidbody2D whiteCloud;
	public Rigidbody2D blackCloud;
	public Rigidbody2D whiteCloud1;
	public Rigidbody2D blackCloud1;
	public Vector3 whitePosition;
	public Vector3 blackPosition;

	public float translationFront;
	public float translationBack;

	List<Rigidbody2D> clouds;

	// Use this for initialization
	void Start () {


		whiteCloud = GameObject.FindGameObjectWithTag ("whiteCloud").GetComponent<Rigidbody2D> ();
		blackCloud = GameObject.FindGameObjectWithTag ("blackCloud").GetComponent<Rigidbody2D> ();
		whitePosition = whiteCloud.transform.position;
		blackPosition = blackCloud.transform.position;
		translationFront = Time.deltaTime * 0.1f;
		translationBack = Time.deltaTime * 0.05f;

				
	}

	// Update is called once per frame
	void Update () {
			
	

		if (whiteCloud.transform.position.x <= -9.65f ) {
			whiteCloud.transform.position = whitePosition;

		}

		if(blackCloud.transform.position.x >= 9.75f ){
			blackCloud.transform.position = blackPosition;

		}


			whiteCloud.transform.Translate (Vector3.left * translationFront);
			whiteCloud.transform.Translate (Vector3.left * translationFront, Space.World);

	
			blackCloud.transform.Translate (Vector3.right * translationFront);
			blackCloud.transform.Translate (Vector3.right * translationFront, Space.World);


	}

}
