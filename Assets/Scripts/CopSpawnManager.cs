using System.Collections;
using UnityEngine;

public class CopSpawnManager : MonoBehaviour
{
	public Object copStandard, copFast, copTank, bossCop;        // Cop Prefabs

	public int startingNumberOfCopsInWave, waveMax, copWaveModiferInbetweenWaves;
	private int randomLane, randomCop;
	private int amountOfCopsInLevel;
	private int waveCount;

	public float startWait, waveWait, spawnWait;

	private GameObject winCondition;
	private GameObject[] lanes, cops;
	private float[] lanePositions = new float[5];

	public int tankCopSpawnChance, fastCopSpawnChance;
	public bool spawnBossCop;
	public float spawnSpeedUpPercentage;

	void Start()
	{
		winCondition = GameObject.Find("WinCondition");
		amountOfCopsInLevel = (waveMax * startingNumberOfCopsInWave) + ((((waveMax * waveMax) - waveMax) / 2) * copWaveModiferInbetweenWaves);
		if (spawnBossCop)
		{
			amountOfCopsInLevel++;
		}
		winCondition.GetComponent<WinCondition>().setCopKillVictory(amountOfCopsInLevel);
		StartCoroutine(spawnWaves());
	}

	IEnumerator spawnWaves()
	{
		lanes = GameObject.FindGameObjectsWithTag("Lane");
		for (int i = 0; i < lanes.Length; i++)
		{
			lanePositions[i] = lanes[i].GetComponent<LanePosition>().laneYPosition;
		}

		bool isSpawning = true;

		yield return new WaitForSeconds(startWait);

		while (isSpawning)
		{
			for (int i = 0; i < startingNumberOfCopsInWave; i++)
			{
				randomLane = Random.Range(0, lanes.Length);
				randomCop = Random.Range(0, 99);

				Vector3 spawnPosition = new Vector3(8, lanePositions[randomLane], 0);

				GameObject cop;

				if (waveCount == 0)
				{
					cop = Instantiate(copStandard, spawnPosition, Quaternion.identity) as GameObject;
				}
				else if (randomCop < tankCopSpawnChance)
				{
					cop = Instantiate(copTank, spawnPosition, Quaternion.identity) as GameObject;
				}
				else if (randomCop < fastCopSpawnChance + tankCopSpawnChance)
				{
					cop = Instantiate(copFast, spawnPosition, Quaternion.identity) as GameObject;
				}
				else
				{
					cop = Instantiate(copStandard, spawnPosition, Quaternion.identity) as GameObject;
				}
				cop.GetComponent<LanePlacement>().lane = lanes[randomLane];

				yield return new WaitForSeconds(spawnWait);
			}

			yield return new WaitForSeconds(waveWait);
			waveCount++;
			startingNumberOfCopsInWave += copWaveModiferInbetweenWaves;
			spawnWait *= spawnSpeedUpPercentage;

			if (waveCount == waveMax)
			{
				if (spawnBossCop)
				{
					yield return new WaitForSeconds(waveWait / 2);

					Vector3 spawnPosition = new Vector3(10, lanePositions[0], 0);
					GameObject cop = Instantiate(bossCop, spawnPosition, Quaternion.identity) as GameObject;
					cop.GetComponent<LanePlacement>().lane = lanes[0];
					cop.GetComponent<LanePlacement>().lane2 = lanes[1];
					cop.GetComponent<LanePlacement>().lane3 = lanes[2];
					cop.GetComponent<LanePlacement>().lane4 = lanes[3];
					cop.GetComponent<LanePlacement>().lane5 = lanes[4];

					GameObject audioSource = GameObject.Find("Audio Source");
					audioSource.GetComponent<ToggleSound>().ToggleAudio();
				}

				isSpawning = false;
			}
		}
	}
}