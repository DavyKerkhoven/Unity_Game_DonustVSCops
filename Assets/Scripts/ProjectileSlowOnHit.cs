using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSlowOnHit : MonoBehaviour
{
	public float slowPercentage;
	public float slowTime;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Cop")
		{
			other.gameObject.GetComponent<Movement>().slowMovementSpeedTemporarily(slowPercentage, slowTime);
		}
	}
}
