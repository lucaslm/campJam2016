using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	Animator anim;
	public bool invincible = false;
	public float duration=5.0f;
	float time;

	void Start() {
		// Set a reference to the player's animations controller
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy"){
			Destroy (other.gameObject);

			if (invincible == false) 
			{
				Destroy (gameObject);
				SceneManager.LoadScene ("main");
				if(other.tag == "EnemyShot")
				{
					Destroy (gameObject);
					SceneManager.LoadScene ("main");
				}
			}
		}

	}
		
	//Invincibility
	public void setInvincible(){
		
		invincible = true;
		anim.SetBool("invincible", true);
		time = 0;

	} 

	void Update(){
		time += Time.deltaTime;
		if (time >= duration && invincible == true) {
			invincible = false;
			anim.SetBool("invincible", false);
		}
	}
}

