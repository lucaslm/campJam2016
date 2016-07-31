using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float acceleration;
	public float topSpeed;
	Rigidbody2D _rb;


	void Start () {
		_rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		_rb.velocity = -transform.right * acceleration;
		var novaVelocidade = _rb.velocity;
		novaVelocidade = Vector3.ClampMagnitude (novaVelocidade, topSpeed);
		_rb.velocity = novaVelocidade;

	}
}
