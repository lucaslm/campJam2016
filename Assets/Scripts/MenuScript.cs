using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour {

	private bool paused = false;
	private GameObject menuCanvas;

	// Use this for initialization
	void Start() {
		menuCanvas = gameObject.transform.FindChild("MenuCanvas").gameObject;
		menuCanvas.SetActive(false);
	}

	public void disableResume() {
		GameObject resumeBtn = menuCanvas.transform.FindChild("ResumeButton").gameObject;
		GameObject restartBtn = menuCanvas.transform.FindChild("RestartButton").gameObject;

		// Disable resume button, since the game is over.
		resumeBtn.SetActive(false);
		// Center the remaining button
		restartBtn.transform.localPosition = Vector3.zero;
		restartBtn.GetComponent<Button>().Select();

		GameObject.Find("EventSystem").GetComponent<EventSystem>().firstSelectedGameObject = restartBtn;
	}

	public IEnumerator endScreen(float delay) {

		float start = Time.realtimeSinceStartup;

		while (Time.realtimeSinceStartup < start + delay) {
			yield return null;
		}

		disableResume();

		if (!paused) {
			togglePause();
		}
	}

	// Resume button onclick event
	public void togglePause() {
		if (paused) {
			Time.timeScale = 1;
		}
		else {
			Time.timeScale = 0;
		}
		paused = !paused;
		menuCanvas.SetActive(paused);
	}

	// Restart button onclick event
	public void restart () {
		togglePause();
		SceneManager.LoadScene ("main");
		GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(SongCodes.LEVEL_THEME);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			togglePause();
		}
	}

}
