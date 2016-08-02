using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {
	public GameObject bullet;
	int anao = 5;
	float tempoEspera;

	// Use this for initialization
	void Start () {
		tempoEspera = 2.0f;
		StartCoroutine (SpawnBullet ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	IEnumerator SpawnBullet ()
	{
		while(anao > 0)
		{	
			yield return new WaitForSeconds (tempoEspera);
			Instantiate (bullet, new Vector3(transform.position.x -1.5f, transform.position.y -0.5f, 0),
				Quaternion.identity);
			
			tempoEspera += 0.4f;
		}
			
	}
}
