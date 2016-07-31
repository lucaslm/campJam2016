using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	Animator anim;
	public bool invincible = false;
	public bool hasLaser = false;
	public float duration=5.0f;
	float time;
	Text scoreTF;

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
				SceneManager.LoadScene ("main");
			} 
			else {
				scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();
			}
		}
	}
		
	//Invincibility
	public void setInvincible(){
		
		invincible = true;
		anim.SetBool("invincible", true);
		time = 0;

	}
	public void setLaserOn(){
		hasLaser = true;
		print (hasLaser);
	}

	void Update(){
		time += Time.deltaTime;
		if (time >= duration && invincible == true) {
			invincible = false;
			anim.SetBool("invincible", false);
			if(hasLaser){
				anim.SetBool ("laserFire",true);
			}
		}
	}
}

