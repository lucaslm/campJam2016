using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {
	public GameObject bullet;
	int anao = 5;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnBullet ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	IEnumerator SpawnBullet ()
	{
		while(anao > 0)
		{	
		yield return new WaitForSeconds (1.8f);
		Instantiate (bullet, new Vector3(transform.position.x, transform.position.y, 0),
				Quaternion.identity);
			//enemyCount--;
		}
			
	}
}
