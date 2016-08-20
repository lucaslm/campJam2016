using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	float time;
	bool canShoot;
	GameObject effect;
	Animator playerAnimator;
	public GameObject shot, laser, laserRepeat, sound, shotPosition, laserPosition;
	public float cooldown = 0.15f, invincibilityDuration = 5.0f, laserDuration = 3.0f;

	// Use this for initialization
	void Start () {
	
		time = 0;
		canShoot = true;

		playerAnimator = GetComponent <Animator> ();
		playerAnimator.SetBool("PlayerDeath", false);

		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		gameObject.GetComponent<PolygonCollider2D>().enabled = true;

		shotPosition  = gameObject.transform.FindChild("PlayerShotPosition").gameObject;
		laserPosition = gameObject.transform.FindChild("PlayerLaserBeamPosition").gameObject;
	
		PlayerInvincibleState playerInvincibleState = playerAnimator.GetBehaviour<PlayerInvincibleState> ();
		playerInvincibleState.setMono(this);
		playerInvincibleState.setInvincibilityDuration(invincibilityDuration);

		PlayerLaserShootingState playerLaserShootingState = playerAnimator.GetBehaviour<PlayerLaserShootingState> ();
		playerLaserShootingState.setMono(this);
		playerLaserShootingState.setLaser(laser);
		playerLaserShootingState.setPlayer(gameObject);
		playerLaserShootingState.setLaserRepeat(laserRepeat);
		playerLaserShootingState.setLaserPosition(laserPosition);
		playerLaserShootingState.setLaserDuration(laserDuration);

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.R) && playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserReady")) {

			playerAnimator.SetTrigger("LaserShoot");

			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.LASER_SHOT);

		}
			
		if (Input.GetKey (KeyCode.Space) && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserShooting") && canShoot) {
			Instantiate (shot, shotPosition.transform.position, Quaternion.identity);
			effect = Instantiate (sound, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
			effect.GetComponent<Songchoice> ().Choice (SoundEffectCodes.PLAYER_SHOT);
			time = 0;
			canShoot = false;
		}

		//Cooldown
		time += Time.deltaTime;
		if (time >= cooldown) {
			canShoot = true;
		}
	}

	IEnumerator triggerLaserDone() {
		yield return new WaitForSeconds (laserDuration);
		playerAnimator.SetTrigger("LaserDone");
	}

	// Function called on the event at the end of death animation
	IEnumerator restartScene() {

		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<PolygonCollider2D>().enabled = false;

		// TODO: make the animation last as much as the sound
		yield return new WaitForSeconds (0.733f);

		SceneManager.LoadScene ("main");

		bool boss = GameObject.Find ("GameManager").GetComponent<Spawner> ().boss;
		if (boss)
			GameObject.Find ("Music(Clone)").GetComponent<Songchoice> ().Song(SongCodes.LEVEL_THEME);

	}

}
