using UnityEngine;
using System.Collections;

public class EnemyBoss : MonoBehaviour {

	Animator bossAnimator;
	public GameObject shot;
	public float maxy = 3.5f;
	public float idleTime = 10f;

	void Start(){

		bossAnimator = GetComponent <Animator> ();

		GameObject shotPosition = gameObject.transform.FindChild("EnemyBossShotPosition").gameObject;

		// On the following lines we pass to the animation controller the objects manipulated on each state

		EnemyBossSummonState enemyBossSummonState = bossAnimator.GetBehaviour<EnemyBossSummonState> ();
		enemyBossSummonState.setMono(this);
		enemyBossSummonState.setBossObj(gameObject);
		enemyBossSummonState.setTopPosition(maxy);
		enemyBossSummonState.setBottomPosition(-maxy);

		EnemyBossIdleState enemyBossIdleState = bossAnimator.GetBehaviour<EnemyBossIdleState> ();
		enemyBossIdleState.setMono(this);
		enemyBossIdleState.setIdleTime(idleTime);

		EnemyBossShootingState enemyBossShootingState = bossAnimator.GetBehaviour<EnemyBossShootingState>();
		enemyBossShootingState.setShot(shot);
		enemyBossShootingState.setShotPosition(shotPosition);

		EnemyBossDeathState enemyBossDeathState = bossAnimator.GetBehaviour<EnemyBossDeathState> ();
		enemyBossDeathState.setBossObj(gameObject);

	}

}