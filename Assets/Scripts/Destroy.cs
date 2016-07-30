using UnityEngine;
using System.Collections;

public class Destroy: MonoBehaviour {


	void OnTriggerEnter2D (Collider2D coll)
	{
		//print ("ahh, tendii");
		if(coll.name == "DestroyThiguis")
		{
			//print ("alo");
			Destroy (gameObject);
		}
	}
}