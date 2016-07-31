using UnityEngine;
using System.Collections;

public class ObjectMovement : MonoBehaviour {

	public float acceleration;
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().AddForce (-transform.right*acceleration*Time.deltaTime);
	}
}
