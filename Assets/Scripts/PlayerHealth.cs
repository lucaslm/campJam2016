using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public bool invincible = false;

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Enemy"){
			Destroy (other.gameObject);

			if (invincible == false) {
				Destroy (gameObject);
				SceneManager.LoadScene ("main");
			}
		}
	}
		
	//Invincibility
	public void setInvincible(){
		invincible = !invincible;
	} 

}
