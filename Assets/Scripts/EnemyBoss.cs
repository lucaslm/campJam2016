using UnityEngine;
using System.Collections;

public class EnemyBoss : MonoBehaviour {

	MenuScript menu;
	Animator bossAnimator;
	public float idleTime = 10f;
	public GameObject shot, sound;

	// Use this for initialization
	void Start() {

		bossAnimator = GetComponent <Animator> ();

		menu = GameObject.Find("Canvas").GetComponent<MenuScript>();

		GameObject shotPosition = gameObject.transform.FindChild("EnemyBossShotPosition").gameObject;

		EnemyBossShootingState enemyBossShootingState = bossAnimator.GetBehaviour<EnemyBossShootingState>();
		enemyBossShootingState.setShotPosition(shotPosition);

	}

	// Function called on the event at the end of death animation
	void destroySelf() {

		Destroy(gameObject);
		Songchoice sc = GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ();
		sc.Song (SongCodes.VICTORY);

		menu.StartCoroutine("endScreen", sc.victory.length);

	}

}