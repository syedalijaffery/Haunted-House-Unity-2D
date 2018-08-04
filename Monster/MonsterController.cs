using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

	float health = 100;

	public bool isDead;
    bool isAttacking;
	public bool start = false;

	AudioSource source;


	Animator anim;

	public GameObject gameManager;

	bool isPlaying;

	// Use this for initialization
	void Start () {
		isPlaying = false;
		isDead = false;
		isAttacking = false;

		anim = GetComponent<Animator> ();

		source = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (!isDead && !isAttacking && start) {

			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", true);
			anim.SetBool ("isAttacking", false);
			transform.Translate (Vector2.left * 2.5f * Time.deltaTime);
			if (!isPlaying) {
				isPlaying = true;
				source.Play ();
			}
		
		} else if (isDead) {

			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);
			anim.SetBool ("isDead", true);


			source.Stop ();

			GetComponent<Rigidbody2D> ().gravityScale = 0f;
			GetComponent<BoxCollider2D> ().isTrigger = true;
		
		} else if (isAttacking) {

			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", true);

		}

	}

	public void decreaseHealth()
	{
		health -= 25f;
		if (health <= 0) {
			isDead = true;
		}
	}

	void OnCollisionStay2D(Collision2D player)
	{
		
		if (player.gameObject.tag == "Player") {

			isAttacking = true;

			player.gameObject.GetComponent<MobileMovementCharacter> ().death ();

			Invoke ("canvasDisplay", 2f);

		}


	}

	public void canvasDisplay()
	{
		gameManager.GetComponent<GameManagerController> ().deathCanvas ();
	}
}
