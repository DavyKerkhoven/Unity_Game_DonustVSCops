using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonutCost : MonoBehaviour
{
	public int donutCost = 75;	// how much the donut will cost - can set in inspector

	void Start()
	{
		GetComponent<Text>().text = donutCost.ToString();
	}
	
	void Update()
	{
		
	}
}
