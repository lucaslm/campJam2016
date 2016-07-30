using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour {

	public float acceleration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().AddForce (-transform.right*acceleration*Time.deltaTime);
	}
}
