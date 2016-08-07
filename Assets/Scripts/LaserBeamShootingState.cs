using UnityEngine;
using System.Collections;

public class LaserBeamShootingState : StateMachineBehaviour {

	GameObject laser, laserRepeat, laserRepeatPosition;

	public void setLaser(GameObject laser) {
		this.laser = laser;
	}

	public void setLaserRepeat(GameObject laserRepeat) {
		this.laserRepeat = laserRepeat;
	}

	public void setLaserRepeatPosition(GameObject laserRepeatPosition) {
		this.laserRepeatPosition = laserRepeatPosition;
	}

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		GameObject laserRepeatInstance = Instantiate (laserRepeat, 
			laserRepeatPosition.transform.position, Quaternion.identity) as GameObject;
		laserRepeatInstance.transform.parent = laser.transform;
	}

}
