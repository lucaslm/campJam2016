using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyShot : MonoBehaviour {

	public float fail = 5.0f;
	float time;

	//When collided.
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Enemy" || other.tag == "EnemyShooter") {
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
