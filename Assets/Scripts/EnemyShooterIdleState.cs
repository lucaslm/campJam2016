using UnityEngine;
using System.Collections;

public class EnemyShooterIdleState : StateMachineBehaviour {

	float idleTime;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		this.idleTime = animator.GetComponent<EnemyShooter>().idleTime;
		animator.gameObject.GetComponent<EnemyShooter>().StartCoroutine (triggerShot (animator));
	}

	IEnumerator triggerShot(Animator animator){
		yield return new WaitForSeconds (idleTime);
		idleTime += 0.4f;
		animator.SetTrigger("EnemyShot");
	}

}
