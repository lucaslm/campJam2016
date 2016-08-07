﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public GameObject sound;
	public int healthPoints;
	Text scoreTF;
	GameObject effect;
	Animator enemyAnimator;

	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponent<Animator>();
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
	}

	void OnTriggerEnter2D(Collider2D coll) {

		if (coll.tag == "PlayerShot") {

			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.HIT);

			switch (gameObject.tag) {
			case "EnemyShooter":
				healthPoints--;
				if (healthPoints <= 0) {
					Destroy (gameObject);
					effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
					effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.KILL);
					scoreTF.text = (int.Parse (scoreTF.text) + 3).ToString ();
				}
				break;
			case "EnemyStatic":
				healthPoints--;
				if (healthPoints <= 0) {
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();
				}
				break;
			case "EnemyDynamic":
				healthPoints--;
				if (healthPoints <= 0) {
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 2).ToString ();
				}
				break;
			case "EnemyBoss":
				healthPoints--;
				if (healthPoints <= 0) {

					// Disable colisions so the boss only dies once
					gameObject.GetComponent<PolygonCollider2D>().enabled = false;

					GameObject.Find ("Music(Clone)").GetComponent<AudioSource> ().Stop();
					effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
					effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.BOSS_DEATH);

					enemyAnimator.SetBool("BossDeath", true);

					scoreTF.text = (int.Parse (scoreTF.text) + 100).ToString ();

				}
				break;
			}

		}

		if (coll.tag == "laser" && gameObject.tag.Contains("Enemy")) {
			Destroy (gameObject);
		}
	}


}
