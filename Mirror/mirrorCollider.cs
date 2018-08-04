using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mirrorCollider : MonoBehaviour {
	 
	Text mirrorText;
	Text interactText;
	Text mainText;

	bool isPlayerColliding;

	bool isClicked;

	string code;

	// Use this for initialization
	void Start () {

		//PlayerPrefs.DeleteKey ("code");
		isClicked = false;
		mainText = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();
		mirrorText = transform.GetChild(1).GetComponentInChildren<Text> ();
	    interactText = transform.GetChild(0).GetComponentInChildren<Text> ();

		if (PlayerPrefs.GetInt ("code") == 1) {
			for (int i = 0; i < 4; i++) {
				
				mirrorText.text = mirrorText.text + " " + ((PlayerPrefs.GetInt ("code" + i)).ToString ());
		    }

		}

		isPlayerColliding = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt ("code") != 1) {

			checkInteraction ();

		} else {

			GetComponent<Collider2D> ().enabled = false;

		}

	}

	public void checkInteraction()
	{
		if (isClicked) {

			PlayerPrefs.SetInt ("code",1);
			for (int i = 0; i < 4; i++) {

				PlayerPrefs.SetInt ("code" + i, Random.Range (0, 6));
				mirrorText.text = mirrorText.text + " " + ((PlayerPrefs.GetInt ("code"+i)).ToString());
				mainText.text = "Looks like a code to something!";
				Invoke ("clearText", 3f);


			}

		}
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {

			interactText.text = "Tap mirror to interact";
			isPlayerColliding = true;

		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			interactText.text = "";
			isPlayerColliding = false;

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

	public void clearText()
	{
		mainText.text = "";
	}
}
