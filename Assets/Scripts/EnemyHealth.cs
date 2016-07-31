using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	int healthShooter, healthStatic, healthMov;
	public bool itsShooter, itsStatic, itsMov;
	Text scoreTF;

	// Use this for initialization
	void Start () {
		scoreTF = GameObject.Find ("ScoreLabel").GetComponents<Text> () [0];
	}
	void Awake(){
		healthStatic = 5;
		healthMov = 2;
		healthShooter = 7;
	}
	
	// Update is called once per frame
	void Update () {
//		print (healthStatic);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
	//	if(coll.tag == "Player")
	//	{
	//		Destroy (coll.gameObject);
	//  }else 
		if(coll.tag == "PlayerShot")
		{
			//print ("é tiroo");
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
				print (healthMov + "alomov");
				if(healthMov <=0)
				{
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 2).ToString ();
				}
			}
			if(itsStatic)
			{
				healthStatic--;
				print (healthStatic);
				if(healthStatic <= 0)
				{
					print ("menos 0");
					Destroy (gameObject);
					scoreTF.text = (int.Parse (scoreTF.text) + 1).ToString ();

				}
			}


		}
	}
}
