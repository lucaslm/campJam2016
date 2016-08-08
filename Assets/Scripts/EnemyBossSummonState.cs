using UnityEngine;
using System.Collections;

public class EnemyBossSummonState : StateMachineBehaviour {

	GameObject bossObj;
	Vector3 topPosition;
	Vector3 bottomPosition;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		bossObj = animator.gameObject;
		float maxy = bossObj.GetComponent<EnemyBoss>().maxy;
		this.topPosition = new Vector3 (bossObj.transform.position.x, maxy, 0);
		this.bottomPosition = new Vector3 (bossObj.transform.position.x, -maxy, 0);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
		animator.gameObject.GetComponent<EnemyBoss>().StartCoroutine (up ());
	}

	IEnumerator up(){
		while (bossObj.transform.position != topPosition) {
			bossObj.transform.position = Vector3.MoveTowards (bossObj.transform.position, topPosition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (0.05f);
		}
		bossObj.GetComponent<EnemyBoss>().StartCoroutine (Down ());
	}

	IEnumerator Down(){
		while (bossObj.transform.position != bottomPosition){
			bossObj.transform.position = Vector3.MoveTowards (bossObj.transform.position, bottomPosition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (0.05f);
		}
		bossObj.GetComponent<EnemyBoss>().StartCoroutine (up ());
	}

}
