﻿using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour
{
	float maxY, minY;
	public GameObject enemy1, topBorder, bottomBorder, nyan;
	public float minTime = 1f;
	public float maxTime = 2f;
	public float spawnTimeShooter = 10f;
	public float timeinbetween = 10.0f;
	public int totalEnemies = 2000;
	public int totalShooters = 10;
	private int enemyCount, shooterCounter, powerCount;
	public GameObject asteroidPrefab, EnemyShooter, Boss;
	public bool doSpawn = true;
	public bool doSpawnShooter = true;
	public bool doSpawnBoss = true;
	bool boss = false;


	void Start() {
		shooterCounter = totalShooters;
		enemyCount = totalEnemies;
		powerCount = 0;
		maxY = topBorder.transform.position.y;
		minY = bottomBorder.transform.position.y;
		StartCoroutine(SpawnEnemy());
		StartCoroutine (SpawnerShooter());
		StartCoroutine(SpawnPowers());
	}

	IEnumerator SpawnEnemy ()
	{
		while (doSpawn && enemyCount > 0) {
			Instantiate (asteroidPrefab, new Vector3(11, Random.Range(5.46f, -6), 0),
				Quaternion.identity);
			enemyCount--;
			yield return new WaitForSeconds (Random.Range (minTime, maxTime));
		}
		if (doSpawnBoss == true) {
			Instantiate (Boss, new Vector3 (7, 0, 0), Quaternion.identity);
			boss = true;
		}
	}

	IEnumerator SpawnPowers()
	{
		yield return new WaitForSeconds (timeinbetween);
		while (doSpawn && !boss) {
			//float waitingTime;
			/*if (powerCount >= (int)(0.5 * totalEnemies)) {
				waitingTime = timeinbetween;
			} else {
				waitingTime = 0.5f * timeinbetween;
			}*/
			/*if (powerCount == totalEnemies / 2) {
				timeinbetween = timeinbetween / 2;
			}*/
			Instantiate (nyan, new Vector3 (11, Random.Range (5.46f, -6), 0), Quaternion.identity);
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
} 