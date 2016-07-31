using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {

	public GameObject sound;
	GameObject effect;


	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Player") {

			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;


			//Invincibility.
			if (gameObject.tag == "Nyan") {
				effect.GetComponent<Songchoice> ().Choice (0);
				other.gameObject.GetComponent<PlayerHealth> ().setInvincible ();

			} 
			else if (gameObject.tag == "Laser") { //Laser.
				other.gameObject.GetComponent<PlayerHealth>() .setlaser();
				effect.GetComponent<Songchoice> ().Choice (1);

			}
			Destroy (gameObject);
		}
	}
}
