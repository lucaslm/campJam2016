using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 playerPos = transform.position;

		Vector3 wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
		float half_height = gameObject.GetComponent<Renderer>().bounds.size.y/2;

		print("playerPos.y = " + playerPos.y);
		print("half_height = " + half_height);
		print("wrld.y = " + wrld.y);
		//if (Input.GetKeyDown (KeyCode.DownArrow) && playerPos.y < (wrld.y - half_height)) {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Vector3 position = this.transform.position;
			position.y--;
			this.transform.position = position;
		}
	}
}
