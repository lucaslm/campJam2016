using UnityEngine;
using System.Collections;

public class EnemyBossShootingState : StateMachineBehaviour {

	GameObject shot;
	GameObject  shotPosition;

	public void setShot(GameObject shot) {
		this.shot = shot;
	}

	public void setShotPosition(GameObject shotPosition) {
		this.shotPosition = shotPosition;
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (!animator.GetBool("BossDeath")) {
			Instantiate (shot, shotPosition.transform.position, Quaternion.identity);
		}
	}

}
