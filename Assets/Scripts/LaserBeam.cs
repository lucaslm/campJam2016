using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		// Make laser Follow the player
		GetComponent<Rigidbody2D> ().velocity = transform.parent.GetComponent<Rigidbody2D> ().velocity;
	}
	
	//When collided.
	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "EnemyStatic"  || other.tag == "EnemyShooter" || other.tag == "EnemyShot") {
			Destroy (other.gameObject);
		}
	}

}
