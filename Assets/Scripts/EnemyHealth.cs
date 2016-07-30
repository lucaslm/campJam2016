using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	int healthShooter, healthStatic, healthMov;
	public bool itsShooter, itsStatic, itsMov;


	// Use this for initialization
	void Start () {
	
	}
	void Awake(){
		healthStatic = 5;
		healthMov = 2;
		healthShooter = 7;
	}
	
	// Update is called once per frame
	void Update () {
		print (healthStatic);
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if(coll.tag == "player")
		{
			Destroy (gameObject);

		}else if(coll.tag == "PlayerShot")
		{
			print ("é tiroo");
			if(itsShooter)
			{
				if(healthShooter <= 0)
				{
					Destroy (gameObject);
				}
			}
			if(itsMov)
			{
				
				healthMov--;
				print (healthMov + "alomov");
				if(healthMov <=0)
				{
					Destroy (gameObject);
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
				}
			}


		}
	}
}
