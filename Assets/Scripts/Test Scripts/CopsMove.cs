using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopsMove : MonoBehaviour
{

	float startingX;
	float startingY;
	float startingZ;

	// Use this for initialization
	void Start()
	{
		startingX = GetComponent<Transform>().position.x;
		startingY = GetComponent<Transform>().position.y;
		startingZ = GetComponent<Transform>().position.z;

		Invoke("testMovement", 3);
	}
	
	// Update is called once per frame
	void Update()
	{

	}

	void testMovement()
	{
		if (startingY != GetComponent<Transform>().position.y)
		{
			IntegrationTest.Fail(gameObject);
		}
		else
		{
			IntegrationTest.Pass(gameObject);
		}

		if (startingZ != GetComponent<Transform>().position.z)
		{
			IntegrationTest.Fail(gameObject);
		}
		else
		{
			IntegrationTest.Pass(gameObject);
		}

		if (startingX == GetComponent<Transform>().position.x)
		{
			IntegrationTest.Fail(gameObject);
		}
		else
		{
			IntegrationTest.Pass(gameObject);
		}
	}
}
