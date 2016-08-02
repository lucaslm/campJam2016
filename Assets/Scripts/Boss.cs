using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	Vector3 finalposition;
	Vector3 bottomposition;
	public float maxy= 3.5f;

	void Start(){

		finalposition = new Vector3 (transform.position.x, maxy, 0);
		bottomposition = new Vector3 (transform.position.x, -maxy, 0);

		StartCoroutine (up ());

	}

	IEnumerator up(){
		while (transform.position != finalposition) {
			transform.position = Vector3.MoveTowards (transform.position, finalposition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (1.5f);
			StartCoroutine (Down ());
		}
	}

	IEnumerator Down(){
		while(transform.position != bottomposition){
			transform.position = Vector3.MoveTowards (transform.position, bottomposition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (1.5f);
			StartCoroutine (up ());
		}


	}

	/*
	 * Function that triggers animation of boss dying, waits for it to end and destroy the boss' game object
	 */
	public IEnumerator Die()
	{
		Animator enemyAnimator = GetComponent<Animator>();
		enemyAnimator.SetTrigger("BossDeath");
		yield return new WaitForEndOfFrame();
		float duration = enemyAnimator.GetCurrentAnimatorClipInfo(0).Length;
		yield return new WaitForSeconds(duration);
		Destroy(gameObject);
	}



}