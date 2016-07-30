using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Destroy: MonoBehaviour {

	void OnTriggerEnter2D (Collider2D coll)
	{
		//print ("ahh, tendii");
		if(coll.name == "DestroyThiguis")
		{
			//print ("alo");
			Destroy (gameObject);
		}
		else if(coll.name == "Player")
		{
			Destroy (gameObject);
			Destroy (GameObject.FindGameObjectWithTag ("Player"));
			SceneManager.LoadScene ("main");
		}
	}
}