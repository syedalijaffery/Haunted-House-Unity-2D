using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileMovementCharacter : MonoBehaviour {
	

	private float ScreenWidth;

	public float speed=4;

	bool facingRight;

	Animator myAnimator;

	bool isMovingRight;

	bool disableControl;

	Vector3 startPosition;

	// Use this for initialization
	void Start () {

		//PlayerPrefs.DeleteKey("isDonePiano");

		float index = PlayerPrefs.GetInt ("positionIndex");

		if (index < 3 && PlayerPrefs.GetInt("positionIndex") != 0) {

			startPosition = GameObject.Find ("Spawn" + index.ToString()).transform.position;
			transform.SetPositionAndRotation (startPosition, Quaternion.Euler (0, 0, 0));

		}


		disableControl = false;
		ScreenWidth = Screen.width;
		myAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		if (!disableControl) {
			if (Input.mousePosition.x >= (ScreenWidth / 2) && Input.GetMouseButton (0)) {
			    
				myAnimator.SetBool ("isDead", false);
				myAnimator.SetBool ("isIdle", false);
				myAnimator.SetBool ("isWalking", true);
			    
				//move right
				RunCharacter (1.0f);
				isMovingRight = true;
			   
			}
			if (Input.mousePosition.x < ScreenWidth / 2 && Input.GetMouseButton (0)) {
			   
				myAnimator.SetBool ("isDead", false);
				myAnimator.SetBool ("isIdle", false);
				myAnimator.SetBool ("isWalking", true);
				//move left
				RunCharacter (-1.0f);

			} else if (Input.GetMouseButtonUp (0)) {

				myAnimator.SetBool ("isDead", false);
				myAnimator.SetBool ("isIdle", true);
				myAnimator.SetBool ("isWalking", false);

			}
		}


	}

	public void RunCharacter(float horizontalInput){
		
		Vector3 scale = transform.localScale;

		if (PlayerPrefs.GetInt ("PlayerSelected") == 0) {
			if (horizontalInput >= 1f) {
			
				if (scale.x > 0) {
					facingRight = !facingRight;
					scale.x *= -1;
					transform.localScale = scale;

				}

				transform.Translate (Vector2.right * speed * Time.deltaTime);
			} else if (horizontalInput <= -1f) {

				if (scale.x < 0) {
					facingRight = !facingRight;
					scale.x *= -1;
					transform.localScale = scale;
				}

				transform.Translate (Vector2.left * speed * Time.deltaTime);

			} else {
				
				isMovingRight = false;

			}

		} else {

			if (horizontalInput >= 1f) {

				if (scale.x < 0) {
					facingRight = !facingRight;
					scale.x *= -1;
					transform.localScale = scale;

				}

				transform.Translate (Vector2.right * speed * Time.deltaTime);
			} else if (horizontalInput <= -1f) {

				if (scale.x > 0) {
					facingRight = !facingRight;
					scale.x *= -1;
					transform.localScale = scale;
				}

				transform.Translate (Vector2.left * speed * Time.deltaTime);

			} else {

				isMovingRight = false;

			}

		}


	}

	public void hidePlayer(bool value)
	{
		gameObject.SetActive (value);

	}

	public void death()
	{
		GetComponent<Animator> ().SetBool ("isIdle",false);
		GetComponent<Animator> ().SetBool ("isWalking",false);
		GetComponent<Animator> ().SetBool ("isDead",true);
		disableControl = true;
		GetComponent<Advertisements> ().ShowAd ();

		//Invoke("showAd",3f);

	}

	public void disableEnable(bool change)
	{
		myAnimator.SetBool ("isWalking", false);
		myAnimator.SetBool ("isIdle", true);
		myAnimator.SetBool ("isDead", false);
		disableControl = change;

	}

	public void moveTo(GameObject obj)
	{
		Vector3 scale = transform.localScale;

		transform.SetPositionAndRotation (obj.transform.position,obj.transform.rotation);

		if ((PlayerPrefs.GetInt ("PlayerSelected") == 0 && scale.x < 0)  || (PlayerPrefs.GetInt ("PlayerSelected") != 0 && scale.x > 0)) {

			scale.x *= -1;
			transform.localScale = scale;

		}
	}

	public void showAd()
	{
		GetComponent<Advertisements> ().ShowAd ();
	}

}
