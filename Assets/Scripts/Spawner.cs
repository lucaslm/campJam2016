﻿using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour
{
	float maxY, minY;
	public GameObject enemy1, topBorder, bottomBorder, nyan;
	public float minTime = 0.3f;
	public float maxTime = 0.7f;
	public float spawnTimeShooter = 10f;
	public float timeinbetween = 10.0f;
	public int totalEnemies = 2000;
	public int totalShooters = 10;
	private int enemyCount, shooterCounter, powerCount;
	public GameObject asteroidPrefab, EnemyShooter;
	public bool doSpawn = true;
	public bool doSpawnShooter = true;


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
			Instantiate (asteroidPrefab, new Vector3(11, Random.Range(minY, maxY), 0),
				Quaternion.identity);
			enemyCount--;
			yield return new WaitForSeconds (Random.Range (minTime, maxTime));
		}
	}

	IEnumerator SpawnPowers()
	{
		while (doSpawn) {
			if (powerCount == 0) {
				yield return new WaitForSeconds (timeinbetween);
			}

			float waitingTime;
			if (powerCount >= (int)(0.5 * totalEnemies)) {
				waitingTime = timeinbetween;
			} else {
				waitingTime = 0.5f * timeinbetween;
			}
			if (powerCount == totalEnemies / 2) {
				timeinbetween = timeinbetween / 2;
			}
			Instantiate (nyan, new Vector3 (11, Random.Range (minY, maxY), 0), Quaternion.identity);
			yield return new WaitForSeconds (waitingTime);
			powerCount++;
		}
	}
	IEnumerator SpawnerShooter ()
	{
		while (doSpawn && shooterCounter > 0) {
			yield return new WaitForSeconds (spawnTimeShooter);
			Instantiate (EnemyShooter, new Vector3(11, Random.Range(minY, maxY), 0),
				Quaternion.identity);
			shooterCounter--;
		}
	}
} 