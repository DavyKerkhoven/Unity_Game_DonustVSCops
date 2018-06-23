using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsTakeDamage : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{
		GetComponent<Health>().takeDamage(20);

		if (GetComponent<Health>().currentHealth < GetComponent<Health>().maxHealth)
		{
			IntegrationTest.Pass(gameObject);
		}
		else
		{
			IntegrationTest.Fail(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}
}
