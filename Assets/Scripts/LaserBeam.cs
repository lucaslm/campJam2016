using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	Material[] materials;
	public int index = 0;
	public GameObject laserRepeat;
	public Material mat0, mat1, mat2, mat3, mat4, mat5;

	private float rightLimit;

	// Use this for initialization
	void Start () {

		materials = new Material[6];
		materials[0] = mat0;//(Material)Resources.Load("Materials/Heyyeahyeh0Material.mat");
		materials[1] = mat1;//(Material)Resources.Load("Materials/Heyyeahyeh1Material.mat");
		materials[2] = mat2;//(Material)Resources.Load("Materials/Heyyeahyeh2Material.mat");
		materials[3] = mat3;//(Material)Resources.Load("Materials/Heyyeahyeh3Material.mat");
		materials[4] = mat4;//(Material)Resources.Load("Materials/Heyyeahyeh4Material.mat");
		materials[5] = mat5;//(Material)Resources.Load("Materials/Heyyeahyeh5Material.mat");

		Vector3 topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 1));
		rightLimit  = topRightCorner.x;

	}

	void changeMaterial() {
		laserRepeat.GetComponent<LineRenderer>().material = materials[index];
		index = (index + 1) % materials.Length;
	}

	// Update is called once per frame
	void Update () {

		// Make laser Follow the player
		GetComponent<Rigidbody2D> ().velocity = transform.parent.GetComponent<Rigidbody2D> ().velocity;

		// Adjust laser repeat size to occupy the entire screen
		var pos = laserRepeat.transform.position;
		pos.x   = rightLimit;
		pos     = laserRepeat.transform.InverseTransformPoint(pos);
		laserRepeat.GetComponent<LineRenderer>().SetPosition(0, pos);

	}
	
	//When collided.
	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "EnemyStatic"  || other.tag == "EnemyShooter" || other.tag == "EnemyShot") {
			Destroy (other.gameObject);
		}
	}

}
