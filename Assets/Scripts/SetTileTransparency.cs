using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTileTransparency : MonoBehaviour
{
	private bool mouseOver;	// this is set to true while the mouse is inside the tile

	// Use this for initialization
	void Start()
	{
		mouseOver = false;

		InvokeRepeating("changeTileColor", 0, 0.1f);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	private void OnMouseOver()
	{
		mouseOver = true;
	}

	private void OnMouseExit()
	{
		mouseOver = false;
	}

	private void changeTileColor()
	{
		bool donutOnTile = GetComponent<TileProperties>().donutOnTile;

		if (mouseOver && donutOnTile)
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 0.6f);
		}
		else if (mouseOver)
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 0.5f, 0.6f);
		}
		else
		{
			GetComponent<SpriteRenderer>().color = new Color(1, 1, 0.5f, 0.3f);
		}
	}
}
