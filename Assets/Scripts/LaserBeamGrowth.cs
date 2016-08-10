using UnityEngine;
using System.Collections;

public class LaserBeamGrowth : MonoBehaviour {

	SpriteRenderer laserRepeatRenderer;

	void Start () {
		laserRepeatRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {

		float screenBound = Camera.main.ViewportToWorldPoint(new Vector3 (1, 1, 0)).x;
		if (laserRepeatRenderer.bounds.max.x < screenBound) {
			float scaleIncrease = (screenBound - laserRepeatRenderer.bounds.max.x)/laserRepeatRenderer.bounds.size.x;
			gameObject.transform.localScale += new Vector3(scaleIncrease, 0, 0);
		}
	}

}
