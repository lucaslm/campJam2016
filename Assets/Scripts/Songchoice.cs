using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public enum SoundEffectCodes {
	NYAN_PICK,
	LASER_PICK,
	HIT,
	KILL,
	LASER_SHOT,
	PLAYER_SHOT,
	ENEMY_SHOT,
	BOSS_CHARGE,
	BOSS_SHOT,
	BOSS_DEATH,
	PLAYER_DEATH

};

public enum SongCodes {
	LEVEL_THEME,
	BOSS_THEME,
	NYAN_THEME,
	VICTORY,
	FINAL
}

[RequireComponent(typeof(AudioSource))]
public class Songchoice : MonoBehaviour {

	float resumeTime;
	AudioSource audioSrc;
	public AudioClip levelTheme, bossTheme, nyanSong, victory, final;
	public AudioClip nyanPick, laserPick, hit, playerDeath, kill, laserShot, playerShot, enemyShot, bossShot, bossCharge, bossDeath;

	void Awake(){
		audioSrc = GetComponent<AudioSource> ();
	}

	public void Choice(SoundEffectCodes choice){
		float dur=1.0f;

		switch (choice) {
		case SoundEffectCodes.NYAN_PICK:
			audioSrc.clip = nyanPick;
			dur = 1.0f;
			break;
		case SoundEffectCodes.LASER_PICK:
			audioSrc.clip = laserPick;
			dur = 1.0f;
			break;
		case SoundEffectCodes.HIT:
			audioSrc.clip = hit;
			audioSrc.volume = 0.1f;
			dur=1.0f;
			break;
		case SoundEffectCodes.PLAYER_DEATH:
			audioSrc.clip = playerDeath;
			dur=1.4f;
			break;
		case SoundEffectCodes.KILL:
			audioSrc.clip = kill;
			audioSrc.volume = 0.4f;
			dur = 3.0f;
			break;
		case SoundEffectCodes.LASER_SHOT:
			audioSrc.clip = laserShot;
			dur = 7.0f;
			break;
		case SoundEffectCodes.PLAYER_SHOT:
			audioSrc.clip = playerShot;
			audioSrc.volume = 0.1f;
			dur = 1.0f;
			break;
		case SoundEffectCodes.ENEMY_SHOT:
			audioSrc.clip = enemyShot;
			audioSrc.volume = 0.2f;
			dur = 1.0f;
			break;
		case SoundEffectCodes.BOSS_CHARGE:
			audioSrc.clip = bossCharge;
			dur = 1.0f;
			break;
		case SoundEffectCodes.BOSS_SHOT:
			audioSrc.clip = bossShot;
			dur = 1.0f;
			break;
		case SoundEffectCodes.BOSS_DEATH:
			audioSrc.clip = bossDeath;
			dur = 6.0f;
			break;
		
		}
		audioSrc.Play ();
		StartCoroutine (cutsound(dur));
	}

	IEnumerator cutsound(float dur){
		yield return new WaitForSeconds (dur);
		audioSrc.volume = 1.0f;
		Destroy (gameObject);
		Destroy (this);
		if (audioSrc.clip == playerDeath)
			SceneManager.LoadScene ("main");
	}

	public void Song(SongCodes music, float advancement = 0) {
		switch (music) {
		case SongCodes.LEVEL_THEME:
			audioSrc.clip = levelTheme;
			resumeTime += advancement;
			if (resumeTime > audioSrc.clip.length) {
				resumeTime -= Mathf.Floor(resumeTime/audioSrc.clip.length);
			}
			audioSrc.time = resumeTime;
			break;
		case SongCodes.BOSS_THEME:
			audioSrc.clip = bossTheme;
			break;
		case SongCodes.NYAN_THEME:
			resumeTime = audioSrc.time;
			audioSrc.clip = nyanSong;
			break;
		case SongCodes.VICTORY:
			audioSrc.clip = victory;
			audioSrc.loop = false;
			break;
		case SongCodes.FINAL:
			audioSrc.clip = final;
			break;
		}
		audioSrc.Play ();
	}

}
