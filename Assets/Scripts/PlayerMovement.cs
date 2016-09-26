﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	PolygonCollider2D playerCollider;
	public float acceleration = 1.0f;
	private Vector3 velocity  = Vector3.zero;

	// Use this for initialization
	void Start () {
		playerCollider = GetComponent <PolygonCollider2D> ();
	}

	// Update is called once per frame
	void Update () {

		// If touch is suported
		if (Input.touchSupported) {

			if (Input.touchCount > 0) {
				var touch = Input.GetTouch(0);
				var pos   = Camera.main.ScreenToWorldPoint(touch.position);
				pos.z     = gameObject.transform.position.z;

				if (!playerCollider.OverlapPoint(pos)) {
					gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, pos, ref velocity, Time.deltaTime * 20.0f);
				}
			}

		} else {

			if (Input.GetKey(KeyCode.UpArrow))
			{
				GetComponent<Rigidbody2D>().AddForce(transform.up * acceleration * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				GetComponent<Rigidbody2D>().AddForce(-transform.right * acceleration * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				GetComponent<Rigidbody2D>().AddForce(transform.right * acceleration * Time.deltaTime);
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				GetComponent<Rigidbody2D>().AddForce(-transform.up * acceleration * Time.deltaTime);
			}

		}

	}
}
