using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainsawMan : MonoBehaviour {

	public float speed;

	bool isWalkingright;

	Vector3 enemyScale;

	Animator anim;

	bool hasKilled;

	bool isKilling;

	Vector3 startPosition;

	// Use this for initialization
	void Start () {

		float index = PlayerPrefs.GetInt ("positionIndex");

		if (index == 2 && PlayerPrefs.HasKey("positionIndex")) {

			startPosition = GameObject.Find ("Spawn1").transform.position;
			transform.SetPositionAndRotation (startPosition,Quaternion.Euler(0,0,0));
		}

		hasKilled = false;

		isKilling = false;

		anim = GetComponent<Animator> ();

		enemyScale = transform.localScale;

		checkWalkingStatus ();

	}

	// Update is called once per frame
	void Update () {
	
		if (!isKilling) {

			checkWalkingStatus ();
			moveEnemy ();

		} else if (!hasKilled) {
		    
			checkPlayerDirection ();

		} else if (hasKilled) {

			Invoke ("invokeRestartButton",1f);
		}

	}

	void checkWalkingStatus()
	{
		if (transform.localScale.x > 0)
			isWalkingright = true;
		else
			isWalkingright = false;
	}

	public void changeDirection()
	{		
		enemyScale.x *= -1;
		transform.localScale = enemyScale;
	}

	void moveEnemy()
	{
		anim.SetBool ("isWalking",true);
		anim.SetBool ("isIdle",false);

		if (isWalkingright) {

			transform.Translate (Vector2.right * speed * Time.deltaTime);

		} else {

			transform.Translate (Vector2.left * speed * Time.deltaTime);
		}

	}

	void OnCollisionStay2D(Collision2D player)
	{
		if (player.gameObject.tag == "Player") {
		    
			isKilling = true;
		
		}


	}

	public void checkPlayerDirection()
	{
		GameObject player = GameObject.Find("Character").gameObject;

		Vector3 playerScale = player.transform.localScale;

		Vector3 playerPosition = player.transform.position;

		if (isWalkingright && (playerScale.x > 0) && (playerPosition.x < transform.position.x)) {

			changeDirection ();

		} else if (!isWalkingright && (playerScale.x < 0) && (playerPosition.x > transform.position.x)) {
		
			changeDirection ();

		}

		FindObjectOfType<MobileMovementCharacter> ().death ();

		killAnimation ();

		hasKilled = true;

	}

	public void killAnimation()
	{
		
		    anim.SetBool ("isIdle",false);
			anim.SetBool ("isWalking",false);
			anim.SetBool ("isKilling", true);
	}

	void invokeRestartButton()
	{
		FindObjectOfType<GameManagerController> ().deathCanvas();
	}
}
