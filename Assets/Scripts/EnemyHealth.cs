using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public GameObject sound;
	public int healthPoints;
	Text scoreTF;
	GameObject effect;
	Animator enemyAnimator;

	// Use this for initialization
	void Start () {
		enemyAnimator = GetComponent<Animator>();
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
	}

	void OnTriggerEnter2D(Collider2D coll)
	{

		if (coll.tag == "PlayerShot")
		{
			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			effect.GetComponent<Songchoice> ().Choice (2);

			switch (gameObject.tag) {
			case "EnemyShooter":
				healthPoints--;
				if (healthPoints <= 0)
				{
					Destroy (gameObject);
					effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
					effect.GetComponent<Songchoice> ().Choice (4);
					scoreTF.text = (int.Parse (scoreTF.text) + 3).ToString ();
				}
				break;
			case "EnemyStatic":
				healthPoints--;
				if (healthPoints <= 0)
				{
					Destroy (gameObject);
					effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
					effect.GetComponent<Songchoice> ().Choice (4);
					scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();
				}
				break;
			case "EnemyDynamic":
				healthPoints--;
				if (healthPoints <=0)
				{
					Destroy (gameObject);
					effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
					effect.GetComponent<Songchoice> ().Choice (4);
					scoreTF.text = (int.Parse (scoreTF.text) + 2).ToString ();
				}
				break;
			case "EnemyBoss":
				// If the boss has been shot, but is not currently already dying, decrease its HP
				if (!enemyAnimator.GetCurrentAnimatorStateInfo(0).IsName("BossDying")) {
					healthPoints--;
					if (healthPoints <= 0) {
						// Start corrotine to animate its death, and disable colisions so we only play it once
						gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
						StartCoroutine(gameObject.GetComponent<Boss> ().Die());

						effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
						effect.GetComponent<Songchoice> ().Choice (10);
						GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song (3, 1); //Victory


						scoreTF.text = (int.Parse (scoreTF.text) + 100).ToString ();
					}
				}
				break;
			}

		}
	}


}
