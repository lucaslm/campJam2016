using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

	Vector3 finalposition;
	Vector3 bottomposition;
	public float maxy= 3.5f;
	Animator bossAnimator;
	AnimationClip deathAnimation;

	void Start(){

		finalposition = new Vector3 (transform.position.x, maxy, 0);
		bottomposition = new Vector3 (transform.position.x, -maxy, 0);

		bossAnimator = gameObject.GetComponent<Animator>();
		foreach (AnimationClip clip in bossAnimator.runtimeAnimatorController.animationClips) {
			print(clip.name);
			// TODO: Find out how to change animation clip name from dsd to BossDiyng on scene
			if (clip.name == "EnemyBossAnimationDying") {
				deathAnimation = clip;
			}
		}

		StartCoroutine (up ());

	}

	IEnumerator up(){
		while (transform.position != finalposition) {
			transform.position = Vector3.MoveTowards (transform.position, finalposition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (0.05f);
		}
		StartCoroutine (Down ());

	}

	IEnumerator Down(){
		while(transform.position != bottomposition){
			transform.position = Vector3.MoveTowards (transform.position, bottomposition, Time.deltaTime * 3f);
			yield return new WaitForSeconds (0.05f);
		}
		StartCoroutine (up ());


	}

	/*
	 * Function that triggers animation of boss dying, waits for it to end and destroy the boss' game object
	 */
	public IEnumerator Die()
	{
		bossAnimator.SetTrigger("BossDeath");
		yield return new WaitForSeconds(deathAnimation.length);
		Destroy(gameObject);
	}



}