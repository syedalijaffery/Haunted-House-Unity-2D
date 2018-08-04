using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TubController : MonoBehaviour {

	bool isClicked;
	bool isPlayerColliding;

	Text tubText;
	Text mainMessage;

	// Use this for initialization
	void Start () {

		mainMessage = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();
		tubText	= transform.GetChild (0).GetComponentInChildren<Text>();

		if (PlayerPrefs.GetInt ("SisterCloset") == 1 || PlayerPrefs.GetInt ("SisterCloset") == 2) {

			GetComponent<Collider2D> ().enabled = false;

		}

	}
	
	// Update is called once per frame
	void Update () {

		interact ();

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

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {
			isPlayerColliding = true;
			mainMessage.text = "There is the KEY in the tub";
			tubText.text = "Tap to interact";
		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {
			isPlayerColliding = false;
			mainMessage.text = "";
			tubText.text = "";
		}
	}

	public void interact()
	{
		if (isClicked) {

			isClicked = false;
			SceneManager.LoadScene ("DragKey");

		}

	}

}
