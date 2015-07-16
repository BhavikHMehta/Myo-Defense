using UnityEngine;
using System.Collections;

public class BombSpawning : MonoBehaviour 
{
	public Castle healthdecrease;
	// Use this for initialization
	void Start () 
	{
		healthdecrease = GameObject.FindGameObjectWithTag("Castle").GetComponent<Castle>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter2D(Collider2D target)
	{
		if (target.gameObject.tag == "Castle") 
		{
			healthdecrease.healthofTheCastle -= 5; 
			Destroy(gameObject);
		}
	}
}
