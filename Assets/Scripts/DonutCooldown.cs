using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DonutCooldown : MonoBehaviour
{
	public bool onCooldown; // if the donut is on cooldown or not
	public float timeStamp; // this will record the system time that the donut should come of cooldown
	public float cooldownTime = 10; // how long the donut will be on cooldown for (changed in inspector)

	void Start()
	{
		onCooldown = false;

		InvokeRepeating("removeDonutCooldown", 0, 0.1f);
	}
	
	void Update()
	{
		
	}

	private void removeDonutCooldown()
	{
		// if the system time is past the timestamp, then remove the cooldown
		if (timeStamp <= Time.time)
		{
			onCooldown = false;
		}
	}

	public void startDonutCooldown()
	{
		onCooldown = true;

		// this will set the system time for the donut to go off cooldown
		timeStamp = Time.time + cooldownTime; 
	}
}
