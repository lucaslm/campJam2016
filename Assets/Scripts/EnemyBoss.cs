using UnityEngine;
using System.Collections;

public class EnemyBoss : MonoBehaviour {

	Animator bossAnimator;
	public float maxy = 3.5f;
	public float idleTime = 10f;
	public GameObject shot, sound;

	// Use this for initialization
	void Start() {

		bossAnimator = GetComponent <Animator> ();

		GameObject shotPosition = gameObject.transform.FindChild("EnemyBossShotPosition").gameObject;

		EnemyBossShootingState enemyBossShootingState = bossAnimator.GetBehaviour<EnemyBossShootingState>();
		enemyBossShootingState.setShotPosition(shotPosition);

	}

	// Function called on the event at the end of death animation
	void destroySelf() {
		Destroy(gameObject);
		GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song (SongCodes.VICTORY);
	}

}