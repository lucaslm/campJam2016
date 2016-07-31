using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Songchoice : MonoBehaviour {

	public AudioClip song1, songBoss, nyan, nyansong, laserpick, hit, dead, kill, lasershot, playershot, enemyshot;
	public AudioClip bossprojectile, bosscharge;
	private AudioSource audio;
	float resumeTime;


	void Awake(){
		audio = GetComponent<AudioSource> ();
	}

	public void Choice(int choice){
		float dur=1.0f;

		switch (choice) {
		case 0:
			audio.clip = nyan;
			dur = 1.0f;
			break;
		case 1:
			audio.clip = laserpick;
			dur = 1.0f;
			break;
		case 2:
			audio.clip = hit;
			dur=1.0f;
			break;
		case 3:
			audio.clip = dead;
			dur=1.0f;
			break;
		case 4:
			audio.clip = kill;
			dur = 3.0f;
			break;
		case 5:
			audio.clip = lasershot;
			dur = 7.0f;
			break;
		case 6:
			audio.clip = playershot;
			dur = 1.0f;
			break;
		case 7:
			audio.clip = enemyshot;
			dur = 1.0f;
			break;
		case 8:
			audio.clip = bosscharge;
			dur = 1.0f;
			break;
		case 9:
			audio.clip = bossprojectile;
			dur = 1.0f;
			break;
		}
		audio.Play ();
		StartCoroutine (cutsound(dur));
	}



	IEnumerator cutsound(float dur){
		yield return new WaitForSeconds (dur);
		Destroy (this);
	}

	public void Song(int song, float duration){
		switch (song) {
		case 0:
			audio.clip = song1;
			audio.time = resumeTime;
			break;
		case 1:
			audio.clip = songBoss;
			break;
		case 2:
			resumeTime = audio.time+duration;
			audio.clip = nyansong;
			break;
		}
		audio.Play();
	}

}
