using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Songchoice : MonoBehaviour {

	public AudioClip song1, songBoss, nyan, nyansong, laserpick, hit, dead, kill, lasershot;
	private AudioSource audio;
	float resumeTime;


	void Awake(){
		audio = GetComponent<AudioSource> ();
	}

	public void Choice(int choice){
		switch (choice) {
		case 0:
			audio.clip = nyan;
			audio.Play ();
			break;
		case 1:
			audio.clip = laserpick;
			audio.Play ();
			break;
		case 2:
			audio.clip = hit;
			audio.Play ();
			break;
		case 3:
			audio.clip = dead;
			audio.Play ();
			break;
		case 4:
			audio.clip = kill;
			audio.Play ();
			break;
		case 5:
			audio.clip = lasershot;
			audio.Play ();
			break;
		}
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
