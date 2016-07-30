using UnityEngine;
using System.Collections;

public class enemySpawner : MonoBehaviour {

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
}
