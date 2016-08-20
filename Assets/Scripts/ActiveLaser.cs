using UnityEngine;
using System.Collections;

public class ActiveLaser : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.R))
		{
			anim.SetBool ("Shooting", true);
			anim.SetBool ("Lasering", true);
		}
	}
}
