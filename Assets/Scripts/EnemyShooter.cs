using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {

	Animator enemyAnimator;
	public float idleTime = 1.0f;
	public GameObject bullet, sound;

	// Use this for initialization
	void Start () {

		enemyAnimator = GetComponent<Animator>();

	}
		
	void SpawnBullet () {

		// Only Shoot if it is not dying
		if (!enemyAnimator.GetBool("EnemyShooterDead")) {

			Vector3 viewPos = Camera.main.WorldToViewportPoint (this.transform.position);

			// Only Shoot if inside the screen
			if ( 0 <= viewPos.x && viewPos.x <= 1) {
				GameObject effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.ENEMY_SHOT);

				Instantiate (bullet, new Vector3(transform.position.x -1.5f, transform.position.y -0.5f, 0),
					Quaternion.identity);
			}
			
		}
			
	}

	// Function called on the event at the end of death animation
	void destroySelf() {
		Destroy(gameObject);
	}

}
