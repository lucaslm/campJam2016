using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {
	Vector3 playerPos, telaPos;
	public float aceleracao;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		playerPos = transform.position;

		telaPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		//float half_height = gameObject.GetComponent<Renderer>().bounds.size.y/2;
		print (telaPos);
		print (playerPos);
		//if (Input.GetKeyDown (KeyCode.DownArrow) && playerPos.y < (wrld.y - half_height)) {

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
