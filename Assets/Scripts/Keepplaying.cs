using UnityEngine;
using System.Collections;

public class Keepplaying : MonoBehaviour {

	public static GameObject instance = null;
	public GameObject inst;

	void Awake(){
		if (instance == null) {
			instance = GameObject.Instantiate<GameObject>(this.inst);
			DontDestroyOnLoad (instance);//transform.gameObject);
		}
	}

	void Update() {
		//Debug.Log(instance.GetComponent<AudioSource> ().time);
	}
}