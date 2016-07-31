using UnityEngine;
using System.Collections;

public class PlayerLaserShot : MonoBehaviour {

	public Animator laserAnim;
	public GameObject LaserG;
	Powerup poweru;
	//int stupidCourotine = 2;
	Vector3 crescido;
	//bool canShoot = false;
	public PlayerHealth playerhealth;

	void Start () {
		crescido = new Vector3 (1, 1, 0);

	//	StartCoroutine (Laser ());
		StartCoroutine (Crescer ());
	}

		
	/*IEnumerator Laser()
	{
		while()
		{
			laserAnim.SetBool ("Shooting",true);
			yield return new WaitForSeconds (6f);
			//laserAnim.SetBool ("Shooting", false);
		}

	}*/
	IEnumerator Crescer()
	{
		while(LaserG.transform.localScale != crescido)
		{
			LaserG.transform.localScale = Vector3.MoveTowards (LaserG.transform.localScale, crescido, Time.deltaTime * 18f);
		}
		yield return new WaitForSeconds (0.0001f);
	}


}
