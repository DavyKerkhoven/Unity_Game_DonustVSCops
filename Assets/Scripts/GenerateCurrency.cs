using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCurrency : MonoBehaviour
{
	public int currencyAmount;
	public int generationTime;
	private GameObject playerCurrency;

	void Start()
	{
		playerCurrency = GameObject.FindWithTag("PlayerCurrency");

		InvokeRepeating("generateCurrency", generationTime, generationTime);
	}

	void Update()
	{

	}

	private void generateCurrency()
	{
		playerCurrency.GetComponent<PlayerCurrency>().gainCurrency(currencyAmount);
	}
}
