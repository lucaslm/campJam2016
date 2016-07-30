using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject shot;
	public float cooldown = 1.0f;
	float time;
	bool cantshoot;

	// Use this for initialization
	void Start () {
		time = 0;
		cantshoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!cantshoot) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				Instantiate (shot, transform.position, Quaternion.identity);
				time = 0;
				cantshoot = true;
			}
		}


		//Cooldown
		time+=Time.deltaTime;
		if (time >= cooldown) {
			cantshoot = false;
		}
	}
}
