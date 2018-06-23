using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceProjectile : MonoBehaviour
{
	public float projectileFireRate;
	public GameObject projectilePrefab;
	private GameObject lane;
	private bool startedShooting = false;

	void Start()
	{
		lane = GetComponent<LanePlacement>().lane;
	}
	
	void Update()
	{
		if (lane.GetComponent<DetectCopInLane>().copsInLane > 0 && startedShooting == false)
		{
			InvokeRepeating("createProjectile", 0, projectileFireRate);
			startedShooting = true;
		}
		else if (lane.GetComponent<DetectCopInLane>().copsInLane == 0)
		{
			CancelInvoke("createProjectile");
			startedShooting = false;
		}
	}

	private void createProjectile()
	{
		Instantiate(projectilePrefab, transform.position, Quaternion.identity);
	}
}
