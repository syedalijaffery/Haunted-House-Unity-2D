using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MovingPlatformScript : MonoBehaviour {

	GameObject rotatingLedge;

	bool isPlayerColliding;

	bool isClicked;

	Text mainMessage;

	GameObject platformText;

	string moveTo;

	bool isMoving; 

	GameObject character,leftPlatform,rightPlatform;

	public bool hasReached;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString ("moveTo","right");
		leftPlatform = GameObject.Find ("StopPlatformLeft");
		rightPlatform = GameObject.Find ("StopPlatformRight");

		if (PlayerPrefs.GetString ("moveTo") == "right") {

			leftPlatform.SetActive (false);

		} else {

			rightPlatform.SetActive (false);
		}




		hasReached = false;

		character = GameObject.Find ("Character");

		isMoving = false;
	
		PlayerPrefs.SetString ("moveTo", "right");

		mainMessage = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();

		platformText = transform.GetChild (2).gameObject;
		platformText.SetActive (false);

		isPlayerColliding = false;
		isClicked = false;

		rotatingLedge = transform.GetChild (1).gameObject;
		rotatingLedge.GetComponent<Rotate> ().enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		movePlatform ();

	}

	void OnTriggerStay2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = true;
			platformText.SetActive (true);

		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = false;
			platformText.SetActive (false);
		}
	}

	public void changeText(Text whichText,string msg)
	{
		whichText.text = msg;
	}

	public void clearMainText()
	{
		mainMessage.text = "";
	}

	void OnMouseOver()
	{
		if (isPlayerColliding){
			if(Input.GetMouseButtonDown(0))
			isClicked = true;
		}
	}

	void OnMouseExit()
	{
		if(!isMoving)
		isClicked = false;
	}

	public void movePlatform()
	{

		if (isClicked) {

			if (PlayerPrefs.GetString ("moveTo") == "right" && !hasReached) {

				rotatingLedge.GetComponent<Rotate> ().enabled = true;
				isMoving = true;
				platformText.SetActive (false);
				character.transform.Translate (Vector2.right * 4 * Time.deltaTime);
				transform.Translate (Vector2.right * 4 * Time.deltaTime);



			} else if (!hasReached) {

				rotatingLedge.GetComponent<Rotate> ().enabled = true;
				isMoving = true;
				platformText.SetActive (false);
				character.transform.Translate (Vector2.left * 4 * Time.deltaTime);
				transform.Translate (Vector2.left * 4 * Time.deltaTime);

			} else {

				isMoving = false;
				hasReached = false;
				isClicked = false;
				rotatingLedge.GetComponent<Rotate> ().enabled = false;

				if (PlayerPrefs.GetString ("moveTo") == "right")
					PlayerPrefs.SetString ("moveTo","left");
				else
					PlayerPrefs.SetString ("moveTo","right");


			}

			if (!leftPlatform.activeSelf)
				leftPlatform.SetActive (true);
			else if (!rightPlatform.activeSelf)
				rightPlatform.SetActive (true);

		}

	}


}
