using UnityEngine;
using System.Collections;

public class LaserBeamGrowth : MonoBehaviour {

	Vector3 finalSize;
	Animator laserAnimator;
	GameObject laserRepeat;

	void Start () {
		laserRepeat = gameObject.transform.FindChild("LaserBeamRepeat").gameObject;
		laserAnimator = GetComponent <Animator> ();
		finalSize = new Vector3 (1, 1, 1);
		Debug.Log("OK");
		StartCoroutine (GrowLaser ());
	}

	public IEnumerator GrowLaser() {
		Debug.Log("Should Grow");
		Debug.Log(laserRepeat.transform.localScale != finalSize); //yields true
		Debug.Log(laserAnimator.GetCurrentAnimatorStateInfo(0).IsName("LaserBeamShooting")); //yields false
		while (laserRepeat.transform.localScale != finalSize && laserAnimator.GetCurrentAnimatorStateInfo(0).IsName("LaserBeamShooting")) {
			Debug.Log("Growing");
			laserRepeat.transform.localScale = Vector3.MoveTowards (laserRepeat.transform.localScale, finalSize, Time.deltaTime * 18f);
		}
		yield return new WaitForSeconds (0.0001f);
	}


}
