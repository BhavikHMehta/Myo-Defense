using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Castle : MonoBehaviour 
{

	public double healthofTheCastle;
	public int round;
	public int coins;
	public int enemyAmountForRound;
	public Text coinAmount;
	public Text roundLevel;
	public Text enemiesLeft;
	public int maxEnemyOnScreen;
	public int currentEnemyAmountonScreen;
	public int enemyAmountRemaining;
	public bool spawnPaused;
	
	public GameObject flyingEnemy;
	public Text roundNotifier;
	string displayRound;
	
	void Start () 
	{
		healthofTheCastle = 100;
		round = 1;
		coins = 0;
		enemyAmountForRound = fib(round);
		enemyAmountRemaining = enemyAmountForRound;
		maxEnemyOnScreen = 2;
		coinAmount = GameObject.FindGameObjectWithTag("coinAmount").GetComponent<Text>();
		roundLevel = GameObject.FindGameObjectWithTag("roundLevel").GetComponent<Text>();
		enemiesLeft = GameObject.FindGameObjectWithTag("enemiesLeft").GetComponent<Text>();
		spawnPaused = false;
		currentEnemyAmountonScreen = GameObject.FindGameObjectsWithTag("flyingEnemy").Length;
		roundNotifier = GameObject.FindGameObjectWithTag("roundNotifier").GetComponent<Text>();
		coinAmount.text = coins.ToString();
		roundLevel.text = "Round: " + round.ToString();
		enemiesLeft.text = "Enemies Left: " + enemyAmountRemaining.ToString();
	
		
	}
	
	// Update is called once per frame
	void Update()
	{		
		if (currentEnemyAmountonScreen < maxEnemyOnScreen && healthofTheCastle!= 0 && enemyAmountRemaining != 0 && !spawnPaused)
		{
			spawnMob();
			
		}
		
		if (enemyAmountRemaining == 0 && healthofTheCastle != 0)
		{
			LevelUp();
			spawnPaused = true;
		}
		
		else if (healthofTheCastle == 0)
		{
			LoadLevel();
		}
	
			
		enemiesLeft.text = "Enemies Left: " + enemyAmountRemaining.ToString();
		coinAmount.text = coins.ToString();
		roundLevel.text = "Round: " + round.ToString();
		currentEnemyAmountonScreen = GameObject.FindGameObjectsWithTag("flyingEnemy").Length;
		
		
		
	}
	
	public int fib(int round)
	{
		int a = 0;
		int b = 1;
		// In N steps compute Fibonacci sequence iteratively.
		for (int i = 0; i < round; i++)
		{
			int temp = a;
			a = b;
			b = temp + b;
		}
		return a;
	}
	
	public void spawnMob()
	{			
		Instantiate(flyingEnemy, new Vector3(100,0,0), Quaternion.identity);
		currentEnemyAmountonScreen = GameObject.FindGameObjectsWithTag("flyingEnemy").Length;
		CancelInvoke("spawnMob");
	}
	
	public void LevelUp()
	{
		GameObject [] enemies = GameObject.FindGameObjectsWithTag("flyingEnemy");
		foreach (GameObject enemy in enemies)
		{
			Destroy(enemy);
		}
		round++;
		displayRound = "NEXT ROUND " + round + "!";
		StartCoroutine(ShowMessage(displayRound, 5));
		enemyAmountForRound = fib (round);
		enemyAmountRemaining = enemyAmountForRound;
	}
	
	IEnumerator ShowMessage (string message, float delay) 
	{
		roundNotifier.text = message;
		roundNotifier.enabled = true;
		enemiesLeft.text = "Enemies Left: " + enemyAmountRemaining.ToString();
		yield return new WaitForSeconds(delay);
		roundNotifier.enabled = false;
		spawnPaused = false;
	}
	
	public void LoadLevel()
	{
		
		Application.LoadLevel ("GameOver");
	}
}
