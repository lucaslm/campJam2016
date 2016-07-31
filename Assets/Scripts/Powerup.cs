using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	
	PlayerHealth playerhealth;

	void Awake()
	{
		//playerhealth = GetComponent<PlayerHealth> ();

	}

	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Player") {

			if (gameObject.tag == "Nyan") {
				other.gameObject.GetComponent<PlayerHealth> ().setInvincible ();

			}
			if(gameObject.tag == "LaserPickUp"){
				//print ("Num e que");
				other.gameObject.GetComponent<PlayerHealth> ().setLaserOn ();
			}

			Destroy (gameObject);
		}
	}
}
