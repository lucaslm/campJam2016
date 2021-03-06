﻿using UnityEngine;
using System.Collections;
public class Spawner : MonoBehaviour
{
	public GameObject EnemyShooter, Boss;
	public GameObject[] meteorArray;
	public GameObject[] powerUpArray;
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
	public bool boss = false;

	private float rightLimit, topLimit, bottomLimit;

	void Start() {
		shooterCounter = totalShooters;
		enemyCount = totalEnemies;
		powerCount = 0;

		Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 1));
		Vector3 bottomLeftCorner = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 1));

		rightLimit  = topRightCorner.x;
		topLimit    = topRightCorner.y;
		bottomLimit = bottomLeftCorner.y;

		StartCoroutine(SpawnEnemy());
		StartCoroutine (SpawnerShooter());
		StartCoroutine(SpawnPowers());
	}

	IEnumerator SpawnEnemy ()
	{
		Vector3[] meteorExtends = new Vector3[meteorArray.Length];
		for (int index = 0; index < meteorArray.Length; index++)
		{
			GameObject meteor = meteorArray[index];
			meteorExtends[index] = meteor.GetComponent<SpriteRenderer>().bounds.extents;
		}
		while (doSpawn && enemyCount > 0) {
			int index = Random.Range(0, meteorArray.Length);
			Vector3 pos = new Vector3(
				rightLimit + meteorExtends[index].x,
				Random.Range(
					bottomLimit + meteorExtends[index].y,
					topLimit    - meteorExtends[index].y
				),
				0
			);
			Instantiate (meteorArray[index], pos, Quaternion.identity);
			enemyCount--;
			yield return new WaitForSeconds (Random.Range (minTime, maxTime));
		}
		if (doSpawnBoss == true) {
			float BossExtendX = Boss.GetComponent<SpriteRenderer>().bounds.extents.x;
			Instantiate (Boss, new Vector3 (rightLimit - BossExtendX, 0, 0), Quaternion.identity);
			GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(SongCodes.BOSS_THEME);
			spawnTimeShooter = 6.0f;
			boss = true;
		}
	}

	IEnumerator SpawnPowers()
	{
		Vector3[] powerUpExtends = new Vector3[powerUpArray.Length];
		for (int index = 0; index < powerUpArray.Length; index++)
		{
			GameObject powerUp = powerUpArray[index];
			powerUpExtends[index] = powerUp.GetComponent<SpriteRenderer>().bounds.extents;
		}
		yield return new WaitForSeconds (timeinbetween);
		while (doSpawn && !boss) {
			int index   = Random.Range(0, powerUpArray.Length);
			Vector3 pos = new Vector3(
				rightLimit + powerUpExtends[index].x,
				Random.Range(
					bottomLimit + powerUpExtends[index].y,
					topLimit    - powerUpExtends[index].y
				),
				0
			);

			Instantiate(powerUpArray[index], pos, Quaternion.identity);

			yield return new WaitForSeconds (timeinbetween); // Era WaitingTime
			powerCount++;
		}
	}

	IEnumerator SpawnerShooter ()
	{
		Vector3 EnemyShooterExtend = EnemyShooter.GetComponent<SpriteRenderer>().bounds.extents;
		while (doSpawnShooter && shooterCounter > 0) {
			yield return new WaitForSeconds (spawnTimeShooter);
			Vector3 pos = new Vector3(
				rightLimit + EnemyShooterExtend.x,
				Random.Range(
					bottomLimit + EnemyShooterExtend.y,
					topLimit    - EnemyShooterExtend.y
				),
				0
			);
			Instantiate (EnemyShooter, pos, Quaternion.identity);
			shooterCounter--;
		}
	}
}
