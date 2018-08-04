using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed;

	bool facingRight;

	Animator myAnimator;

	Vector3 startPosition;

	// Use this for initialization
	void Start () {
        
		//PlayerPrefs.DeleteAll ();
		speed = 5;
		facingRight = false;
		myAnimator = GetComponent<Animator> ();
	

	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_Player
			Movement ();
		#endif

	}

//	private void MovementMobile(float horizontalInput){
//		speed = horizontalInput;
//		Vector3 scale = transform.localScale;
//
//		if (horizontalInput >= 1)
//		{
//			myAnimator.SetBool ("isIdle",false);
//			myAnimator.SetBool ("isWalking",true);
//
//			if (scale.x < 0)
//			{
//				facingRight = !facingRight;
//				scale.x *= -1;
//				transform.localScale = scale;
//			}
//
//			transform.Translate(Vector2.right * speed * Time.deltaTime);
//		}
//		else if (horizontalInput <= -1)
//		{
//			myAnimator.SetBool ("isIdle",false);
//			myAnimator.SetBool ("isWalking",true);
//
//			if (scale.x > 0)
//			{
//				facingRight = !facingRight;
//				scale.x *= -1;
//				transform.localScale = scale;
//			}
//
//			transform.Translate(Vector2.left * speed * Time.deltaTime);
//
//		}
//		else if(horizontalInput == 0)
//		{
//
//			myAnimator.SetBool ("isIdle",true);
//			myAnimator.SetBool ("isWalking",false);
//
//		}
//
//	}

	void Movement()
	{
		Vector3 scale = transform.localScale;

		if (Input.GetKey(KeyCode.D))
		{
			//myAnimator.SetBool ("isIdle",false);
			//myAnimator.SetBool ("isWalking",true);
			if(myAnimator.gameObject.activeSelf)
			myAnimator.SetBool ("isWalking",true);

			if (scale.x < 0)
			{
				facingRight = !facingRight;
				scale.x *= -1;
				transform.localScale = scale;
			}

			transform.Translate(Vector2.right * speed * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			//myAnimator.SetBool ("isIdle",false);
			//myAnimator.SetBool ("isWalking",true);

			if(myAnimator.gameObject.activeSelf)
			myAnimator.SetBool ("isWalking",true);

			if (scale.x > 0)
			{
				facingRight = !facingRight;
				scale.x *= -1;
				transform.localScale = scale;
			}

			transform.Translate(Vector2.left * speed * Time.deltaTime);

		}
		else
		{
			if(myAnimator.gameObject.activeSelf)
			myAnimator.SetBool ("isWalking",false);
				
		}
	}

	public void hidePlayer(bool value)
	{
		gameObject.SetActive (value);
		//if (!value) {

			//myAnimator.SetBool ("isWalking", false);
		//}
	}

	public void death()
	{
		

	}

}
