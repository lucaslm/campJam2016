﻿using UnityEngine;
using System.Collections;

public class DestroySelf: MonoBehaviour {


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