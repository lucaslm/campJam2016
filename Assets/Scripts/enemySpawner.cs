﻿using UnityEngine;
using System.Collections;
public class enemySpawner : MonoBehaviour
{
	float maxY, minY;
	public  GameObject enemy1, topBorder, bottomBorder;
	public float minTime = 0.3f;
	public float maxTime = 0.7f;
	public float spawnTimeShooter = 10f;
	public int count = 2000;
	public int countShooter = 10;
	public GameObject asteroidPrefab, EnemyShooter;
	public bool doSpawn = true;
	public bool doSpawnShooter = true;

	void Start() {
			maxY = topBorder.transform.position.y;
			minY = bottomBorder.transform.position.y;
		StartCoroutine(Spawner());
		StartCoroutine (SpawnerShooter ());

	}
		void Update(){
			
		}
			
	IEnumerator Spawner ()
		{
			while (doSpawn && count > 0) {
				Instantiate (asteroidPrefab, new Vector3(11, Random.Range(minY, maxY), 0),
					Quaternion.identity);
				count--;
				yield return new WaitForSeconds (Random.Range (minTime, maxTime));
			}
		}
		IEnumerator SpawnerShooter ()
		{
		while (doSpawn && countShooter > 0) {
			yield return new WaitForSeconds (spawnTimeShooter);
				Instantiate (EnemyShooter, new Vector3(11, Random.Range(minY, maxY), 0),
					Quaternion.identity);
			countShooter--;
			}
		}
	} 

	/*public class enemySpawner : MonoBehaviour {

		float maxY, minY;
		public  GameObject enemy1, topBorder, bottomBorder;
		private GameObject[] prefabList;

		// Use this for initialization
		void Start () {
			maxY = topBorder.transform.position.y;
			minY = bottomBorder.transform.position.y;
			prefabList    = new GameObject[1];
			prefabList[0] = enemy1;
			InvokeRepeating("SpawnEnemy", 50f, 1);
		
		}

		void SpawnEnemy() {
		}
		
		// Update is called once per frame
		void Update () {
			int prefabIndex  = Random.Range(0, prefabList.Length);
			GameObject enemy = Instantiate(prefabList[prefabIndex],
			                              new Vector3(11, Random.Range(minY, maxY), 0),
			                              Quaternion.identity) as GameObject;

		}
}*/

