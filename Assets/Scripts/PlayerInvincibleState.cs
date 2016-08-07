using UnityEngine;
using System.Collections;

public class PlayerInvincibleState : StateMachineBehaviour {

	MonoBehaviour mono;
	float startTime, elapsedTime, invincibilityDuration;

	public void setInvincibilityDuration(float invincibilityDuration) {
		this.invincibilityDuration = invincibilityDuration;
	}

	public void setMono(MonoBehaviour mono) {
		this.mono = mono;
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		elapsedTime = 0;
		mono.StartCoroutine (exitState (animator));
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		elapsedTime += Time.deltaTime;
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		elapsedTime += Time.deltaTime;
	
		// Back to normal theme. If the player pauses while on invincible mode, 
		// elapsedTime will be greater than invincibilityDuration
		// TODO: Sometimes it is the boss theme playing, not the normal theme.
		// We should store the previous sound to know which one to resume
		GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song (SongCodes.LEVEL_THEME, elapsedTime);
	}

	IEnumerator exitState(Animator animator){
		yield return new WaitForSeconds (invincibilityDuration);
		animator.SetBool("invincible", false);

	}

}
