using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCurrency : MonoBehaviour
{
	public int currency = 0;     // the starting currency the player will have - updated in inspector

	// Use this for initialization
	void Start()
	{
		InvokeRepeating("updateCurrencyText", 0, 0.1f);
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void spendCurrency(int value)
	{
		currency -= value;
	}

	public void gainCurrency(int value)
	{
		currency += value;
	}

	private void updateCurrencyText()
	{
		GetComponent<Text>().text = currency.ToString();
	}
}
