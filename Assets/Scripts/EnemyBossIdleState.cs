using UnityEngine;
using System.Collections;

public class EnemyBossIdleState : StateMachineBehaviour {

	float idleTime;
	MonoBehaviour mono;

	public void setIdleTime(float idleTime) {
		this.idleTime = idleTime;
	}

	public void setMono(MonoBehaviour mono) {
		this.mono = mono;
	}
	
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		mono.StartCoroutine (triggerShot (animator));
	}

	IEnumerator triggerShot(Animator animator){
		yield return new WaitForSeconds (idleTime);
		animator.SetTrigger("BossShot");
	}

}
