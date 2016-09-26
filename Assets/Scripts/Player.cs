using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	float time;
	bool isShooting;
	GameObject effect;
	Animator playerAnimator;
	PolygonCollider2D playerCollider;
	public GameObject shot, laser, laserRepeat, sound, shotPosition, laserPosition;
	public float cooldown = 0.15f, invincibilityDuration = 5.0f, laserDuration = 3.0f;

	// Use this for initialization
	void Start () {

		isShooting = false;

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

		playerCollider = GetComponent<PolygonCollider2D>();
		InvokeRepeating("shootBullet", 0, cooldown);

	}

	// Update is called once per frame
	void Update () {

		if (Input.touchSupported) {
			if (Input.touchCount > 0) {
				updatePlayer(Input.GetTouch(0));
			}
		} else {
			updatePlayer();
		}

	}

	void updatePlayer() {
		if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserReady") &&
			Input.GetKeyDown(KeyCode.R)) {
			shootLaser();
		}
		if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerDying") &&
			!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserShooting")) {
			isShooting = Input.GetKey(KeyCode.Space);
		} else {
			isShooting = false;
		}
	}

	void updatePlayer(Touch touch) {
		Debug.Log("touch.tapCount = " + touch.tapCount);
		var pos = Camera.main.ScreenToWorldPoint(touch.position);
			pos.z = gameObject.transform.position.z;

		if (!playerCollider.OverlapPoint(pos)) {
			return;
		}

		if (playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserReady") &&
			touch.phase == TouchPhase.Ended &&
			touch.tapCount == 2) {
			shootLaser();
		}
		if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerDying") &&
			!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("PlayerLaserShooting")) {
			if (touch.phase == TouchPhase.Ended &&
				touch.tapCount == 1) {
				isShooting = !isShooting;
			}

		} else {
			isShooting = false;
		}
	}

	void shootBullet() {
		if (isShooting) {
			Instantiate(shot, shotPosition.transform.position, Quaternion.identity);
			effect = Instantiate(sound, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
			effect.GetComponent<Songchoice>().Choice(SoundEffectCodes.PLAYER_SHOT);
		}
	}

	void shootLaser() {
		playerAnimator.SetTrigger("LaserShoot");
		effect = Instantiate(sound, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
		effect.GetComponent<Songchoice>().Choice(SoundEffectCodes.LASER_SHOT);
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
