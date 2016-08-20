using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyPlayerShot : MonoBehaviour {

	// If the player is able to shot many times per second,
	// and fail is big enough, a scene might end up with
	// a lot of prefabs, thus lagging the game.
	public float fail = 2.0f;
	float time;

	//When collided.
	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "EnemyStatic"  || other.tag == "EnemyShooter" || other.tag == "EnemyBoss") {
			Destroy (gameObject);
		}
	}

	//Failsafe
	void Update (){

		if (Input.GetKey (KeyCode.Space)) {
			time=0;
		}

		time+=Time.deltaTime;
		if (time>=fail){
			Destroy (gameObject);
		}
	}
}
