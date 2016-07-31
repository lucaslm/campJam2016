using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour
{
	public GameObject topBorder, bottomBorder, rightBorder, nyan, laser;
	public GameObject meteor0, meteor1, meteor2, EnemyShooter, Boss;
	private GameObject[] meteorList;
	public float minTime = 1f;
	public float maxTime = 2f;
	public float spawnTimeShooter = 10f;
	public float timeinbetween = 10.0f;
	public int totalEnemies = 2000;
	public int totalShooters = 10;
	private int enemyCount, shooterCounter, powerCount;
	public bool doSpawn = true;
	public bool doSpawnShooter = true;
	public bool doSpawnBoss = true;
	bool boss = false;


	void Start() {
		shooterCounter = totalShooters;
		enemyCount = totalEnemies;
		powerCount = 0;
		meteorList    = new GameObject[3];
		meteorList[0] = meteor0;
		meteorList[1] = meteor1;
		meteorList[2] = meteor2;
		StartCoroutine(SpawnEnemy());
		StartCoroutine (SpawnerShooter());
		StartCoroutine(SpawnPowers());
	}

	IEnumerator SpawnEnemy ()
	{
		while (doSpawn && enemyCount > 0) {
			int index = Random.Range(0, meteorList.Length);
			Instantiate (meteorList[index], new Vector3(11, Random.Range(5.46f, -6), 0),
				Quaternion.identity);
			enemyCount--;
			yield return new WaitForSeconds (Random.Range (minTime, maxTime));
		}
		if (doSpawnBoss == true) {
			GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(1, 5);//Boss song.
			Instantiate (Boss, new Vector3 (7, 0, 0), Quaternion.identity);
			boss = true;
		}
	}

	IEnumerator SpawnPowers()
	{
		yield return new WaitForSeconds (timeinbetween);
		while (doSpawn && !boss) {
			/*
			float waitingTime;
			if (powerCount >= (int)(0.5 * totalEnemies)) {
				waitingTime = timeinbetween;
			} else {
				waitingTime = 0.5f * timeinbetween;
			}
			if (powerCount == totalEnemies / 2) {
				timeinbetween = timeinbetween / 2;
			}
			*/
			if (Random.Range ((int)0, (int)2) == 0) {
				Instantiate (nyan, new Vector3 (11, Random.Range (5.46f, -6), 0), Quaternion.identity);
			} else {
				Instantiate (laser, new Vector3 (11, Random.Range (5.46f, -6), 0), Quaternion.identity);
			}
			yield return new WaitForSeconds (timeinbetween); // Era WaitingTime
			powerCount++;
			
		}
	}
	IEnumerator SpawnerShooter ()
	{
		while (doSpawn && shooterCounter > 0) {
			yield return new WaitForSeconds (spawnTimeShooter);
			Instantiate (EnemyShooter, new Vector3(11, Random.Range(5.46f, -6), 0),
				Quaternion.identity);
			shooterCounter--;
		}
	}
}