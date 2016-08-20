using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	
	//Animator playerAnimator;
	public float acceleration = 1.0f;

	// Use this for initialization
	//void Start () {
	//	playerAnimator = GetComponent <Animator> ();
	//}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (transform.up * acceleration * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (-transform.right * acceleration * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (transform.right * acceleration * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (-transform.up * acceleration * Time.deltaTime);
		}

	}
}
