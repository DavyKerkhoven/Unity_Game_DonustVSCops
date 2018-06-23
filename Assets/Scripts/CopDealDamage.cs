
using UnityEngine;

public class CopDealDamage : MonoBehaviour
{
	public double damageAmount;    // the amount of damage the cop will do - set this in the inspector
	public float attackSpeed;
	private Collider[] donutInFrontOfCop; // the donut that will be in front of the cop (null if there is no donut)

	private int donutsthisCopIsAttacking = 0;

	void Start()
	{
		InvokeRepeating("dealDamageToDonut", 0.5f, attackSpeed);    // repeadetly call this method every x seconds
		donutInFrontOfCop = new Collider[10];
	}

	void Update()
	{

	}

	void OnTriggerEnter(Collider collider)
	{
		if (isColliderADonut(collider))
		{
			donutInFrontOfCop[donutsthisCopIsAttacking++] = collider;
			setCopMovement(CopMoveState.STOPPED);
		}
	}

	private void dealDamageToDonut()
	{
		if (isDonutInFrontOfCop())
		{
			if (donutsthisCopIsAttacking <= 0)
			{
				donutInFrontOfCop = new Collider[10];
			}

			damageDonut();
		}
	}


	//------------------------
	//---- Little Methods ----
	//------------------------

	private void damageDonut()
	{
		for (int donut = 0; donut < 10; donut++)
		{
			if (donutInFrontOfCop[donut] != null)
			{
				donutInFrontOfCop[donut].gameObject.GetComponent<Health>().takeDamage(damageAmount);
				this.gameObject.GetComponent<AudioSource>().Play();
			}
		}
	}

	private bool isColliderADonut(Collider obj)
	{
		if (obj.gameObject.tag == "Donut")
		{
			return true;
		}

		return false;
	}

	private bool isDonutInFrontOfCop()
	{
		if (donutInFrontOfCop != null) // if donutInFrontOfCop is not null, that means there is a donut in front of the cop
		{
			return true;
		}

		return false;
	}

	private void setCopMovement(CopMoveState moveState)
	{
		if (moveState == CopMoveState.MOVING)
		{
			GetComponent<Movement>().setMoveSpeedToDefault();
		}
		else if (moveState == CopMoveState.STOPPED)
		{
			GetComponent<Movement>().setMoveSpeedStopped();
		}
	}

	private enum CopMoveState
	{
		MOVING, STOPPED
	}

	public void copKilledDonut()
	{
		donutsthisCopIsAttacking--;
	}

	public int getDonutsThisCopIsAttacking()
	{
		return donutsthisCopIsAttacking;
	}
}
