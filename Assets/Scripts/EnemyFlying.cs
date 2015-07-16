using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyFlying : MonoBehaviour 
{

	public Rigidbody2D enemy;
	public Vector3 enemyPosition;
	public double max;
	public GameObject bombs;
	public GameObject flyingEnemy;
	public bool droppedBomb;
	public Animator animations;
	public Castle healthdecrease;
	public int direction;
	public Vector3 leftToRight;
	public Vector3 rightToLeft;
	public Vector3 tempVar;
	public bool doNotMove;
	public AudioClip myclip;
	
	// Use this for initialization
	void Start () 
	{
		direction = Random.Range(0,2);
		droppedBomb = true;
		enemy = this.GetComponent<Rigidbody2D>();
		enemyPosition = enemy.transform.position;
		animations = this.GetComponent<Animator>();
		healthdecrease = GameObject.FindGameObjectWithTag("Castle").GetComponent<Castle>();
		rightToLeft = new Vector3(1,1,1);
		leftToRight = new Vector3(-1,1,1);
		doNotMove = false;
		
		this.GetComponent<AudioSource>().clip = myclip;
		
		
		if (direction == 0)
		{
			tempVar = new Vector3 (9f, 0f, 0f);
			enemy.transform.position = tempVar;	
		}
		else
		{
			tempVar = new Vector3 (9f, 0f, 0f);
			enemy.transform.position = -tempVar;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (direction == 0)
		{
			enemy.transform.localScale = rightToLeft;
		
			if (!doNotMove)
			{
				enemyPosition.x = enemy.transform.position.x - (0.009f +(healthdecrease.round*0.005f));
			}
			max = Random.Range(0.5f , 1f);
		}
		
		if (direction == 1)
		{
			enemy.transform.localScale = leftToRight;
			if (!doNotMove)
			{
				enemyPosition.x = enemy.transform.position.x + (0.009f + (healthdecrease.round*0.005f));
			}
			
			max = Random.Range(-0.5f, -1f);
		}
		
		
		enemy.transform.position = enemyPosition;
		
		
		droppedBomb = true;
		if (enemyPosition.x >= 0.05 && enemyPosition.x <= max)
		{
			InvokeRepeating("spawnBombs", 2f, 0.5f);
			doNotMove = true;
			enemyPosition.x = enemy.transform.position.x;
		}
		else if (enemyPosition.x >= max && enemyPosition.x <=0)
		{
			InvokeRepeating("spawnBombs", 2f, 0.5f);
			doNotMove = true;
			enemyPosition.x = enemy.transform.position.x;
		}
		
	}
	
	void spawnBombs()
	{
		if (droppedBomb)
		{
			Instantiate(bombs, enemyPosition, Quaternion.identity);
			CancelInvoke("spawnBombs");
		}
	}
	
	
	public void hitButton()
	{
		editMetrics();
		animations.SetInteger("state", 1);
		Destroy(gameObject, 1f);
	}
	
	public void editMetrics()
	{
		healthdecrease.enemyAmountRemaining -= 1;
		healthdecrease.coins += 10;
		CancelInvoke("editMetrics");
	}
	
	public void ShootSoundEffect()
	{
		this.GetComponent<AudioSource>().Play();
	}
	
	
}
