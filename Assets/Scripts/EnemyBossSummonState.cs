using UnityEngine;
using System.Collections;

public class EnemyBossSummonState : StateMachineBehaviour {

	MonoBehaviour mono;
	GameObject bossObj;
	Vector3 topPosition;
	Vector3 bottomPosition;

	public void setBossObj(GameObject bossObj) {
		this.bossObj = bossObj;
	}

	public void setMono(MonoBehaviour mono) {
		this.mono = mono;
	}

	public void setTopPosition(float topPosition) {
		this.topPosition = new Vector3 (bossObj.transform.position.x, topPosition, 0);
	}

	public void setBottomPosition(float bottomPosition) {
		this.bottomPosition = new Vector3 (bossObj.transform.position.x, bottomPosition, 0);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		bossObj.GetComponent<PolygonCollider2D>().enabled = true;
		mono.StartCoroutine (up ());
	}

	IEnumerator up(){
		while (bossObj.transform.position != topPosition) {
			bossObj.transform.position = Vector3.MoveTowards (bossObj.transform.position, topPosition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (0.05f);
		}
		mono.StartCoroutine (Down ());
	}

	IEnumerator Down(){
		while (bossObj.transform.position != bottomPosition){
			bossObj.transform.position = Vector3.MoveTowards (bossObj.transform.position, bottomPosition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (0.05f);
		}
		mono.StartCoroutine (up ());
	}

}
