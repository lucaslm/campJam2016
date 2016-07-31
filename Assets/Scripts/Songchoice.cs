using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Songchoice : MonoBehaviour {

	public AudioClip song1, songBoss, nyan, nyansong, laser, hit, dead, kill;
	private AudioSource audio;


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
			audio.clip = laser;
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
		}
	}

	public void Song(int song){
		switch (song) {
		case 0:
			audio.clip = song1;
			audio.Play ();
			break;
		case 1:
			audio.clip = songBoss;
			audio.Play ();
			break;
		case 2:
			audio.clip = nyansong;
			audio.Play ();
			break;

		}
	}

}
