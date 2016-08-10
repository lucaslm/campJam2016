using UnityEngine;
using System.Collections;

public class PlayerLaserShootingState : StateMachineBehaviour {

	MonoBehaviour mono;
	float laserDuration;
	GameObject player, laser, laserRepeat, laserInstance, laserPosition;

	public void setMono(MonoBehaviour mono) {
		this.mono = mono;
	}

	public void setLaser(GameObject laser) {
		this.laser = laser;
	}

	public void setPlayer(GameObject player) {
		this.player = player;
	}

	public void setLaserRepeat(GameObject laserRepeat) {
		this.laserRepeat = laserRepeat;
	}

	public void setLaserPosition(GameObject laserPosition) {
		this.laserPosition = laserPosition;
	}

	public void setLaserDuration(float laserDuration) {
		this.laserDuration = laserDuration;
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		laserInstance          = Instantiate (laser, laserPosition.transform.position, Quaternion.identity) as GameObject;
		laserInstance.transform.parent = player.transform;
		Animator laserAnimator = laserInstance.GetComponent<Animator>();
		LaserBeamShootingState laserBeamShootingState = laserAnimator.GetBehaviour<LaserBeamShootingState>();
		laserBeamShootingState.setLaser(laserInstance);
		laserBeamShootingState.setLaserRepeat(laserRepeat);
		mono.StartCoroutine (triggerLaserDone (animator));
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Destroy(laserInstance);
	}

	IEnumerator triggerLaserDone(Animator animator) {
		yield return new WaitForSeconds (laserDuration);
		animator.SetTrigger("LaserDone");
		player.GetComponent<Rigidbody2D>().WakeUp();
	}

}
