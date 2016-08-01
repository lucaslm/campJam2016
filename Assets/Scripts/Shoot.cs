using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject shot;
	public float cooldown = 1.0f;
	float time;
	bool cantshoot;
	public GameObject sound;
	GameObject effect;

	// Use this for initialization
	void Start () {
		time = 0;
		cantshoot = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!cantshoot) {
			if (Input.GetKey (KeyCode.Space)) {
				Instantiate (shot, transform.position, Quaternion.identity);
				effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				effect.GetComponent<Songchoice> ().Choice (6);
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
