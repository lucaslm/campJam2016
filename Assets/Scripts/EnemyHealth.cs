using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	int healthShooter, healthStatic, healthMov, healthBoss;
	public bool itsShooter, itsStatic, itsMov, itsBoss;
	Text scoreTF;

	// Use this for initialization
	void Start () {
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
	}
	void Awake(){
		healthStatic = 5;
		healthMov = 2;
		healthShooter = 7;
		healthBoss = 100;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "PlayerShot")
		{
			if(itsShooter)
			{
				healthShooter--;
				if(healthShooter <= 0)
				{
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 3).ToString ();
				}
			}
			if(itsMov)
			{
				
				healthMov--;
				if(healthMov <=0)
				{
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 2).ToString ();
				}
			}
			if(itsStatic)
			{
				healthStatic--;
				if(healthStatic <= 0)
				{
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();
				}
			}
			if (itsBoss) {
				healthBoss--;
				print (healthBoss);
				if (healthBoss <= 0) {
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 100).ToString ();
				}
			}
		}
	}
}
