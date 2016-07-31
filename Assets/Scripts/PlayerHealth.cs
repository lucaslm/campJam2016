using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	Animator anim;
	public bool invincible = false;
	public bool readytofire=false;
	public float duration=5.0f;
	float time;
	Text scoreTF;
	GameObject HitBoxLaser;

	void Start() {
		// Set a reference to the player's animations controller
		anim = GetComponent<Animator>();
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
		HitBoxLaser = GameObject.Find ("HitBoxLaser");
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

	public void setlaser(){

		readytofire = true;

	}

	void Update(){
		time += Time.deltaTime;
		if (time >= duration && invincible == true) {
			invincible = false;
			anim.SetBool ("invincible", false);
		}

		if (Input.GetKeyDown (KeyCode.R) && readytofire==true) {

			float LaserHeight = HitBoxLaser.GetComponent<Collider> ().bounds.extents [1];
			print ("Shooting");

			GameObject[] allObjects = GameObject.FindGameObjectsWithTag ("Enemy");
			foreach (GameObject GO in allObjects) {
				float GOHeight = GO.GetComponent<Renderer> ().bounds.extents [1];
				boundPoint
				print ("LaserHeight = "+LaserHeight);
				print (Mathf.Abs(GO.transform.position.y - HitBoxLaser.transform.position.y));
				if (GO.transform.position.x > HitBoxLaser.transform.position.x &&
					Mathf.Abs(GO.transform.position.y - HitBoxLaser.transform.position.y) <= LaserHeight) {
					Destroy (GO);
				}
			}		    
			
		}
	}
}

