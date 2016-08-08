using UnityEngine;
using System.Collections;

public class EnemyBossDeathState : StateMachineBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Destroy(animator.gameObject);
		GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song (SongCodes.VICTORY);
	}

}
