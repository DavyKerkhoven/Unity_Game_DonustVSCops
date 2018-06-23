using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public double maxHealth = 10;       // the max health the object will have
	[HideInInspector] public double currentHealth;      // the current health of the object - this will be set to the max health when initizliaed

	void Start()
	{
		currentHealth = maxHealth;
	}

	void Update()
	{

	}

	public void takeDamage(double damage)
	{
		currentHealth -= damage;
	}
}
