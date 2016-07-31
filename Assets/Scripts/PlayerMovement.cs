using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float aceleracao;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		//Movimentação do personagem
		if (Input.GetKey (KeyCode.UpArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (transform.up * aceleracao * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (-transform.right * aceleracao * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (transform.right * aceleracao * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			GetComponent<Rigidbody2D> ().AddForce (-transform.up * aceleracao * Time.deltaTime);
		}

	}
}
