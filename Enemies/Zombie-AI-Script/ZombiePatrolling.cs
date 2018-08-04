using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePatrolling : MonoBehaviour {

	public Transform[] patrolpoints;

	int currentPoint;

	public float speed=0.5f;

	public float timestill=2f;

	public float sight=3f;

	Animator anim;

	Vector3 startPosition;

	public float force;

	bool hasKilled;

	bool isKilling;

	bool isWalkingright;

	Vector3 enemyScale;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		StartCoroutine ("Patrol");

		anim.SetBool("IsWalking",true);
		Physics2D.queriesStartInColliders = false;

		float index = PlayerPrefs.GetInt ("positionIndex");

		if (index == 2 && PlayerPrefs.HasKey("positionIndex")) {

			startPosition = GameObject.Find ("Spawn1").transform.position;
			transform.SetPositionAndRotation (startPosition,Quaternion.Euler(0,0,0));
		}

		hasKilled = false;

		isKilling = false;

	}

	// Update is called once per frame
	void Update () {
		RaycastHit2D hit= Physics2D.Raycast (transform.position, transform.localScale.x * Vector2.right, sight);
		if (hit.collider != null && hit.collider.tag == "Player") {
			GetComponent<Rigidbody2D> ().AddForce (Vector3.up * force + (hit.collider.transform.position - transform.position) * force);
		}
		if (!isKilling) {

			checkWalkingStatus ();


		} else if (!hasKilled) {

			checkPlayerDirection ();

		} else if (hasKilled) {

//			Invoke ("invokeRestartButton",1f);
		}


	}


	IEnumerator Patrol()
	{
		while (true) {

			if(transform.position.x== patrolpoints[currentPoint].position.x )
			{
				currentPoint++;
				anim.SetBool("IsIdle",true);
				anim.SetBool("IsWalking",false);

				yield return new WaitForSeconds(timestill);
				anim.SetBool("IsWalking",true);
				anim.SetBool("IsIdle",false);

			}


			if(currentPoint >=patrolpoints.Length)
			{
				currentPoint=0;
			}

			transform.position=Vector2.MoveTowards(transform.position,new Vector2(patrolpoints[currentPoint].position.x,transform.position.y),speed);

			if(transform.position.x> patrolpoints[currentPoint].position.x)
				transform.localScale=new Vector3(-1,1,1);
			else if (transform.position.x< patrolpoints[currentPoint].position.x)
				transform.localScale= Vector3.one;


			yield return null;


		}
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			anim.SetBool ("isIdle", false);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isKilling", true);
			hasKilled = true;
			isKilling = true;
			other.gameObject.GetComponent<MobileMovementCharacter> ().death ();
			Invoke ("invokeRestartButton",1f);

		}
			
	}


	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawLine (transform.position, transform.position + transform.localScale.x * Vector3.right * sight);

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

		anim.SetBool ("isIdle", false);
		anim.SetBool ("isWalking", false);
		anim.SetBool ("isKilling", true);

		hasKilled = true;

	}

	void invokeRestartButton()
	{
		FindObjectOfType<GameManagerController> ().deathCanvas();
	}

	}


