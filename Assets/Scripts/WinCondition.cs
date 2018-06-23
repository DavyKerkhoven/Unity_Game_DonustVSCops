using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
	private int copKillVictory;	// the amount of cops you need to kill to win the game --set in inspector--
	public int copsKilled;      // this will keep track of how many cops have been killed so far

	public int copDefeat;		// the amount of cops that are aloud to get through before you lose --set in inspector--
	public int copsPassed;		// this will keep track of how many cops have reached the end

	private GameObject winLoseText; // the object that holds the text that comes on the screen that says victory or defeat
	// Use this for initialization
	void Start()
	{
		winLoseText = GameObject.Find("VictoryLoseText");
		winLoseText.GetComponent<Text>().text = " ";

		InvokeRepeating("checkIfThePlayerHasWonOrLost", 0, 0.3f);
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	private void checkIfThePlayerHasWonOrLost()
	{
		if (checkPlayerLose())
		{
			winLoseText.GetComponent<Text>().text = "DEFEAT";
			winLoseText.GetComponent<Text>().color = new Color(255, 0, 0);

			Time.timeScale = 0;
		}
		else if (checkPlayerWin())
		{
			winLoseText.GetComponent<Text>().text = "VICTORY";
			winLoseText.GetComponent<Text>().color = new Color(0, 255, 0);
			//Time.timeScale = 0;
			GameObject uiManager = GameObject.Find("UIManager");
			uiManager.GetComponent<UIManager>().showVictoryOptions();
		}
	}

	bool checkPlayerWin()
	{
		// if the amount of cops killed is greater then the amount required for victory, return true to win the game
		if (copsKilled >= copKillVictory)
		{
			return true;
		}
		return false;
	}

	bool checkPlayerLose()
	{
		// if the amount of cops that have passed is greater then then amount required to lose, return true to lose the game
		if (copsPassed >= copDefeat)
		{
			return true;
		}
		return false;
	}

    public void setCopKillVictory(int NumberOfCops)
    {
        this.copKillVictory = NumberOfCops;
    }
}
