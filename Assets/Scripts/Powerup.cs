using UnityEngine;
using System.Collections;

public class Powerup : MonoBehaviour {
	
	//PlayerHealth playerhealth;
	public GameObject sound;
	GameObject effect;

	void OnTriggerEnter2D (Collider2D other){

		if (other.tag == "Player") {
			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			if (gameObject.tag == "Nyan") {

				effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.NYAN_PICK);
				other.gameObject.GetComponent<Animator>().SetBool("invincible", true);
				GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(SongCodes.NYAN_THEME);

			}
			else if (gameObject.tag == "Laser") {

				effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.LASER_PICK);
				other.gameObject.GetComponent<Animator>().SetTrigger("LaserLoad");

			}

			Destroy (gameObject);
		}
	}
}
