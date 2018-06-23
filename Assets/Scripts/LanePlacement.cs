using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanePlacement : MonoBehaviour
{
	private string tileName;
	public GameObject lane;

	public GameObject lane2;
	public GameObject lane3;
	public GameObject lane4;
	public GameObject lane5;

	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	public void setTileNameString(string theTileName)
	{
		tileName = theTileName;
	}

	public string getTileNameString()
	{
		return tileName;
	}
}
