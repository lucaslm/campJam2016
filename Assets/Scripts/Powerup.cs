using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Player") {

			if (gameObject.tag == "Nyan") {

				Debug.Log ("nois");
				other.gameObject.GetComponent<PlayerHealth> ().setInvincible ();
			}
			Destroy (gameObject);
		}
	}
}
