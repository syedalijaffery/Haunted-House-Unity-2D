using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PianoController : MonoBehaviour {

	public bool isPlayerColliding; 

    Text pianoText;
	Text mainMessage;
	bool isClicked;
	bool ishovered;

	// Use this for initialization
	void Start () {
		isClicked = false;

		ishovered = false;

		mainMessage = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();

		pianoText = transform.GetChild (0).GetComponentInChildren<Text>();
		changeText (pianoText,""); 

		isPlayerColliding = false;

		if (!PlayerPrefs.HasKey ("pianoKeyMissing")) {
			
			PlayerPrefs.SetString ("pianoKeyMissing", "true");

		}

		if (PlayerPrefs.GetString ("isDonePiano") == "yes") {

			GetComponent<Collider2D> ().enabled = false;

		}

	}
	
	// Update is called once per frame
	void Update () {
		if(!FindObjectOfType<GameManagerController>().isPaused)
		checkPianoKey ();
	}

//	void OnMouseOver()
//	{
//		Debug.Log ("Yes!");
//	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {
		
			isPlayerColliding = true;
			changeText (pianoText,"Tap piano to interact");
		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = false;
			changeText (pianoText,"");
		}
	}

	public void checkPianoKey()
	{
		if (isPlayerColliding) {
			
			if (isClicked) {
				isClicked = false;
				if (PlayerPrefs.GetString ("pianoKeyMissing") == "true") {

					changeText (mainMessage, "Need to find missing piano Key");
					Invoke ("clearMainText", 2f);

				} else if(PlayerPrefs.GetString ("pianoKeyMissing") == "false"){

					SceneManager.LoadScene ("Piano");

				}

			}
		}
	}

	void OnMouseOver()
	{
		if (isPlayerColliding) {
			if (Input.GetMouseButtonDown (0))
				isClicked = true;
		}
	}

	void OnMouseExit()
	{
		isClicked = false;
	}

	void changeText(Text whichText,string msg)
	{
		whichText.text = msg;
	}

	void clearMainText()
	{
		mainMessage.text = "";
	}
}
