using UnityEngine;
using UnityEngine.UI;

public class CheckDonutAvailableForPurchase : MonoBehaviour
{
	public bool donutAvialable = false; // to figure out if the donut is available or not
	private GameObject playerCurrency;  // used to check how much currency the player has
	public int donutCost;

	void Start()
	{
		playerCurrency = GameObject.FindWithTag("PlayerCurrency");

		setDonutCost();

		InvokeRepeating("checkDonutAvialable", 0, 0.1f);
	}

	void Update()
	{

	}

	private void checkDonutAvialable()
	{
		donutAvialable = false;

		if (isDonutAvailableForPurchase())
		{
			donutAvialable = true;
			setDonutShade(DonutAvailability.AVAILABLE);
		}
		else
		{
			setDonutShade(DonutAvailability.UNAVAILABLE);
		}
	}


	bool checkPlayerHasEnoughMoneyForDonut()
	{
		if (playerCanAffordDonut())
		{
			return true;
		}

		return false;
	}

	bool checkDonutOnCooldown()
	{
		if (!(GetComponent<DonutCooldown>().onCooldown))
		{
			return true;
		}

		return false;
	}





	//------------------------
	//---- Little Methods ----
	//------------------------

	private void setDonutCost()
	{
		// iterate through all the children, and find the one that is called donut cost
		for (int child = 0; child < transform.childCount - 1; child++)
		{
			if (transform.GetChild(child).transform.name == "Donut Cost")
			{
				// save the cost of the donut into this variable
				donutCost = transform.GetChild(child).GetComponent<DonutCost>().donutCost;
			}
		}
	}

	private bool playerCanAffordDonut()
	{
		if (donutCost <= playerCurrency.GetComponent<PlayerCurrency>().currency)
		{
			return true;
		}

		return false;
	}

	private bool isDonutAvailableForPurchase()
	{
		if (checkPlayerHasEnoughMoneyForDonut() && checkDonutOnCooldown())
		{
			return true;
		}

		return false;
	}

	private void setDonutShade(DonutAvailability availability)
	{
		// sets the color of the image in the donut panel so the player can see visually if the donut
		// is avialable or not
		if (availability == DonutAvailability.AVAILABLE)
		{
			GetComponent<Image>().color = new Color32(255, 255, 255, 255);
		}
		else if (availability == DonutAvailability.UNAVAILABLE)
		{
			GetComponent<Image>().color = new Color32(50, 50, 50, 255);
		}
	}

	private enum DonutAvailability
	{
		AVAILABLE, UNAVAILABLE
	}
}
