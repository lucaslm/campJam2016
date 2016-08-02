using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	Animator anim, animaLaser;
	public GameObject Steven;
	public bool readyToFire = false;
	public bool invincible = false;
	public bool hasLaser = false;
	public float duration=5.0f;
	float time;
	Text scoreTF;
	public GameObject sound;
	GameObject effect;

	void Start() {
		// Set a reference to the player's animations controller
		anim = GetComponent<Animator>();
		animaLaser = GetComponentInChildren<Animator> ();
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		// Whenever the player is touched by an enemy or enemy shot
		if (other.tag.Contains("Enemy")) {
			Destroy (other.gameObject);

			// If invincible, a point is given
			if (invincible) {
				scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();
			}
			// otherwise he dies
			else {
				Destroy (gameObject);
				effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				effect.GetComponent<Songchoice> ().Choice (3);
				SceneManager.LoadScene ("main");
			}
		}
	}

	// Invincibility
	public void setInvincible(){
		GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(2, duration); //Nyan Song
		invincible = true;
		anim.SetBool("invincible", true);
		time = 0;

	}
	public void setLaserOn(){
		hasLaser = true;
		anim.SetBool("Shooting", true);
		animaLaser.SetBool ("Shooting", true);
		anim.SetBool ("laserFire",true);
		//Steven.SetActive (true);
	}
	public void setLaserOff(){
		hasLaser = false;
		anim.SetBool("Shooting", false);
		animaLaser.SetBool ("Shooting", false);
		anim.SetBool ("laserFire",false);
		//Steven.SetActive (false);
	}

	void Update(){


		if(Input.GetKeyDown (KeyCode.R))
		{
			setLaserOn ();
			print ("Ativou");
		}
		if(Input.GetKeyDown(KeyCode.T))
		{
			setLaserOff ();
		}
		time += Time.deltaTime;
		if (time >= duration && invincible == true) {
			invincible = false;
			GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(0, duration); //Back to normal song.
			anim.SetBool("invincible", false);
			if (Input.GetKeyDown (KeyCode.R) && readyToFire) {

				effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				effect.GetComponent<Songchoice> ().Choice (5);

				// TODO: make laser code	    

			}
		}
	}
}

