using UnityEngine;
using System.Collections;

public class EnemyBossIdleState : StateMachineBehaviour {

	float idleTime;
	
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.idleTime = animator.gameObject.GetComponent<EnemyBoss>().idleTime;
		animator.gameObject.GetComponent<EnemyBoss>().StartCoroutine (triggerShot (animator));
	}

	IEnumerator triggerShot(Animator animator){
		yield return new WaitForSeconds (idleTime);
		animator.SetTrigger("BossShot");
	}

}
