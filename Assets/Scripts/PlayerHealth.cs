using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	Text scoreTF;
	GameObject effect;
	Animator playerAnimator;
	public GameObject sound;

	void Start() {
		// Set a reference to the player's animations controller
		playerAnimator = GetComponent<Animator>();
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// Whenever the player is touched by an enemy or enemy shot
		if (other.tag.Contains("Enemy")) {
			Destroy (other.gameObject);

			// If invincible, a point is given
			if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerInvincible")) {
				scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();
			}
			// otherwise he dies
			else {
				Destroy (gameObject);
				effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.PLAYER_DEATH);
			}
		}
	}

}

