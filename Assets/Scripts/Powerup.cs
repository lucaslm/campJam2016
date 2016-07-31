using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Player") {

			//Invincibility.
			if (gameObject.tag == "Nyan") {
				other.gameObject.GetComponent<PlayerHealth> ().setInvincible ();
			} 
			else if (gameObject.tag == "Laser") { //Laser.
				other.gameObject.GetComponent<PlayerHealth>() .setlaser();
			}

			Destroy (gameObject);
		}
	}
}
