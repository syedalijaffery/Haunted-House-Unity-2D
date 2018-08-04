using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour {

	Text mainText;

	bool isPlayerColliding;

	Text keyText;

	public string doorName;

	// Use this for initialization
	void Start () {


		isPlayerColliding = false;

		keyText = transform.GetChild (0).GetComponentInChildren<Text> ();

		mainText = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();

		if (PlayerPrefs.HasKey (doorName)) {
		    
			Destroy (gameObject);
		
		}
		
	}
	
	// Update is called once per frame
	void Update () {

		checkInteraction ();

	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {

			keyText.text = "I";
			isPlayerColliding = true;

		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			keyText.text = "";
			isPlayerColliding = false;

		}
	}

	public void checkInteraction()
	{
		if (isPlayerColliding && Input.GetKeyDown (KeyCode.I)) {
		
			PlayerPrefs.SetString (doorName,"available");
			mainText.text = "Key Found";
			Invoke ("clearText",0.4f);
		
		}
	}

	public void clearText()
	{
		mainText.text = "";
		Destroy (gameObject);
	}



}
