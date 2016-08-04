using UnityEngine;
using System.Collections;

public class EnemyBossDeathState : StateMachineBehaviour {

	GameObject bossObj;

	public void setBossObj(GameObject bossObj) {
		this.bossObj = bossObj;
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Destroy(bossObj);
	}

}
