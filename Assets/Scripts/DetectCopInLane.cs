using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCopInLane : MonoBehaviour
{
	public bool copActive = false;
	public int copsInLane = 0;

	void Start()
	{
		
	}

	void OnTriggerEnter(Collider cop)
	{
		if (cop.gameObject.tag == "Cop")
		{
			copsInLane++;
		}
	}
}
