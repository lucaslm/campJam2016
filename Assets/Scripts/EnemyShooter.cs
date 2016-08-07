using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
	
	int anao = 5;
	float tempoEspera;
	GameObject effect;
	public GameObject bullet, sound;

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

			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.ENEMY_SHOT);

			Instantiate (bullet, new Vector3(transform.position.x -1.5f, transform.position.y -0.5f, 0),
				Quaternion.identity);
			
			tempoEspera += 0.4f;
		}
			
	}
}
