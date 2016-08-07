using UnityEngine;
using System.Collections;

public class EnemyBossShootingState : StateMachineBehaviour {

	GameObject shot, shotPosition, effect, sound;

	public void setShot(GameObject shot) {
		this.shot = shot;
	}

	public void setSound(GameObject sound) {
		this.sound = sound;
	}

	public void setShotPosition(GameObject shotPosition) {
		this.shotPosition = shotPosition;
	}

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
		effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.BOSS_CHARGE);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (!animator.GetBool("BossDeath")) {
			Instantiate (shot, shotPosition.transform.position, Quaternion.identity);
		}
	}

}
