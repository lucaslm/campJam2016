using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	Animator anim;
	public bool invincible  = false;
	public bool readytofire = false;
	public float duration   = 5.0f;
	float time;
	Text scoreTF;
	public GameObject sound;
	GameObject effect;

	void Start() {
		// Set a reference to the player's animations controller
		anim = GetComponent<Animator>();
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy" || other.tag == "EnemyShooter" || other.tag == "EnemyShot"){
			Destroy (other.gameObject);

			if (invincible == false) {
				Destroy (gameObject);
				effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				effect.GetComponent<Songchoice> ().Choice (3);
				SceneManager.LoadScene ("main");
			} 
			else {
				scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();
			}
		}
	}
		
	//Invincibility
	public void setInvincible(){

		GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(2, duration); //Nyan Song
		invincible = true;
		anim.SetBool("invincible", true);
		time = 0;

	} 

	public void setlaser(){

		readytofire = true;

	}

	void Update(){
		time += Time.deltaTime;
		if (time >= duration && invincible == true) {
			anim.SetBool ("invincible", false);
			invincible = false;
			GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(0, duration); //Back to normal song.
		}

		if (Input.GetKeyDown (KeyCode.R) && readytofire) {

			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			effect.GetComponent<Songchoice> ().Choice (5);

			// TODO: make laser code	    
			
		}
	}
}

