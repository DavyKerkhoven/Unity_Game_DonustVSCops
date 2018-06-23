using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
	public string selectedDonutName = "";
	public bool cursorChanged = false;

	void Start()
	{

	}

	void Update()
	{

	}

	public void setCursorToDefault()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
		cursorChanged = false;
	}
}
