using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDealDamage : MonoBehaviour
{
	public double damageAmount = 0;

	void Start()
	{

	}

	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cop")
		{
			other.gameObject.GetComponent<Health>().takeDamage(damageAmount);
			Destroy(gameObject);
		}        
	}
}
