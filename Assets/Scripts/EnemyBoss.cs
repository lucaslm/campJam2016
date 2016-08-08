using UnityEngine;
using System.Collections;

public class EnemyBoss : MonoBehaviour {

	Animator bossAnimator;
	public float maxy = 3.5f;
	public float idleTime = 10f;
	public GameObject shot, sound;

	void Start(){

		bossAnimator = GetComponent <Animator> ();

		GameObject shotPosition = gameObject.transform.FindChild("EnemyBossShotPosition").gameObject;

		EnemyBossShootingState enemyBossShootingState = bossAnimator.GetBehaviour<EnemyBossShootingState>();
		enemyBossShootingState.setShotPosition(shotPosition);


	}

}