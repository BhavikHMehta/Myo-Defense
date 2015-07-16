using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CastleHealth : MonoBehaviour 
{

	public Castle healthDecrease;
	public Image heart;
	public Text percentValue;
	public int value;
	// Use this for initialization
	void Start () 
	{
		healthDecrease = GameObject.FindGameObjectWithTag("Castle").GetComponent<Castle>();
		heart = GameObject.FindGameObjectWithTag("healthFill").GetComponent<Image>();
		percentValue = GameObject.FindGameObjectWithTag("healthPercent").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		heart.fillAmount = (float)((healthDecrease.healthofTheCastle) / 100f);
		value = (int)(heart.fillAmount * 100);
		percentValue.text = value.ToString();
	}
}
