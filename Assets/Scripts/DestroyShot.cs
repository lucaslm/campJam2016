using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DestroyShot : MonoBehaviour {

	public float fail = 5.0f;
	private Text scoreTF;
	float time;

	// Use this for initialization
	void Start () {
		scoreTF = GameObject.Find("ScoreLabel").GetComponents<Text>()[0];
	}

	//When collided.
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Enemy" || other.tag == "EnemyShooter") {
			Destroy (gameObject);
			//Destroy (other.gameObject);
			//scoreTF.text = (int.Parse(scoreTF.text) + 1).ToString();
		}
	}


	//Failsafe
	void Update (){

		if (Input.GetKey (KeyCode.Space)) {
			time=0;
		}

		time+=Time.deltaTime;
		if (time>=fail){
			Destroy (gameObject);
		}
	}
}
