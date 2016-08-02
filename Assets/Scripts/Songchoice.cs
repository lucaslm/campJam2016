using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Songchoice : MonoBehaviour {

	public AudioClip song1, songBoss, nyan, nyansong, laserpick, hit, dead, kill, lasershot, playershot, enemyshot;
	public AudioClip bossprojectile, bosscharge, dieboss, victory, final;
	private AudioSource audioSrc;
	float resumeTime;


	void Awake(){
		audioSrc = GetComponent<AudioSource> ();
	}

	public void Choice(int choice){
		float dur=1.0f;

		switch (choice) {
		case 0:
			audioSrc.clip = nyan;
			dur = 1.0f;
			break;
		case 1:
			audioSrc.clip = laserpick;
			dur = 1.0f;
			break;
		case 2:
			audioSrc.clip = hit;
			dur=1.0f;
			break;
		case 3:
			audioSrc.clip = dead;
			dur=1.0f;
			break;
		case 4:
			audioSrc.clip = kill;
			dur = 3.0f;
			break;
		case 5:
			audioSrc.clip = lasershot;
			dur = 7.0f;
			break;
		case 6:
			audioSrc.clip = playershot;
			dur = 1.0f;
			break;
		case 7:
			audioSrc.clip = enemyshot;
			dur = 1.0f;
			break;
		case 8:
			audioSrc.clip = bosscharge;
			dur = 1.0f;
			break;
		case 9:
			audioSrc.clip = bossprojectile;
			dur = 1.0f;
			break;
		case 10:
			audioSrc.clip = dieboss;
			dur = 2.0f;
			break;
		case 11:
			audioSrc.clip = victory;
			dur = 3.0f;
			break;
		case 12:
			audioSrc.clip = final;
			dur = 4.0f;
			break;
		
		}
		audioSrc.Play ();
		StartCoroutine (cutsound(dur));
	}



	IEnumerator cutsound(float dur){
		yield return new WaitForSeconds (dur);
		Destroy (gameObject);
		Destroy (this);
	}

	public void Song(int song, float duration){
		switch (song) {
		case 0:
			audioSrc.clip = song1;
			audioSrc.time = resumeTime;
			break;
		case 1:
			audioSrc.clip = songBoss;
			break;
		case 2:
			resumeTime = audioSrc.time+duration;
			audioSrc.clip = nyansong;
			break;
		}
		audioSrc.Play();
	}

}
