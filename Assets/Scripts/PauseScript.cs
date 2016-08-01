using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

	private Image pauseImage;
	private bool paused = false;

	void Start() {
		pauseImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (paused)
				Time.timeScale = 1;
			else
				Time.timeScale = 0;
			paused = !paused;
			pauseImage.enabled = !pauseImage.enabled;
		}
	}
}
