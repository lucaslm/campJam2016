using UnityEngine;
using System.Collections;

public class DestroySelf: MonoBehaviour {


	void OnTriggerEnter2D (Collider2D coll)
	{
		if(coll.name == "DestroyThiguis")
		{
			Destroy (gameObject);
		}
	}
}