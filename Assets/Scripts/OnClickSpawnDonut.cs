
using UnityEngine;

public class OnClickSpawnDonut : MonoBehaviour
{
	public GameObject donutCurrency, donutStandard, donutSlowing, donutTank;

	private GameObject donutClone;           // the donut that the prefab will be instansiated into
	private GameObject cursorManager;
	private GameObject playerCurrency;

	void Start()
	{
		cursorManager = GameObject.Find("Cursor Manager");
		playerCurrency = GameObject.FindWithTag("PlayerCurrency");
	}

	void Update()
	{

	}

	private void OnMouseOver()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (canPlaceATower())
			{
				PlaceTower();

				playerCurrency.GetComponent<PlayerCurrency>().spendCurrency(getDonutCost());

				cursorManager.GetComponent<CursorManager>().setCursorToDefault();

				GetComponent<TileProperties>().donutOnTile = true;
			}
		}
	}

	private void PlaceTower()
	{
		string donutName = cursorManager.GetComponent<CursorManager>().selectedDonutName;
		// Create the donut
		if (donutName.Equals("Donut_Currency"))
		{
			donutClone = Instantiate(donutCurrency, transform.position, Quaternion.identity) as GameObject;
		}
		else if (donutName.Equals("Donut_Standard"))
		{
			donutClone = Instantiate(donutStandard, transform.position, Quaternion.identity) as GameObject;
		}
		else if (donutName.Equals("Donut_Slowing"))
		{
			donutClone = Instantiate(donutSlowing, transform.position, Quaternion.identity) as GameObject;
		}
		else if (donutName.Equals("Donut_Tank"))
		{
			donutClone = Instantiate(donutTank, transform.position, Quaternion.identity) as GameObject;
		}

		// Set some propities of the donut so it knows its name and place
		donutClone.GetComponent<LanePlacement>().setTileNameString(this.transform.name);
		donutClone.GetComponent<LanePlacement>().lane = GetComponent<TileProperties>().lane;

		putDonutOnCooldown();
	}




	//------------------------
	//---- Little Methods ----
	//------------------------
	
	private bool canPlaceATower()
	{		
		if (cursorManager.GetComponent<CursorManager>().cursorChanged && GetComponent<TileProperties>().donutOnTile == false)
		{
			return true;
		}

		return false;
	}

	private int getDonutCost()
	{
		return GameObject.Find(cursorManager.GetComponent<CursorManager>().selectedDonutName).GetComponent<CheckDonutAvailableForPurchase>().donutCost;
	}

	private void putDonutOnCooldown()
	{
		GameObject donut = GameObject.Find(cursorManager.GetComponent<CursorManager>().selectedDonutName);
		donut.GetComponent<DonutCooldown>().startDonutCooldown();
	}
}
