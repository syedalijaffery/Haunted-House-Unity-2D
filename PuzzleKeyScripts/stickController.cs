using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stickController : MonoBehaviour {

	bool isPlayerColliding;

	Text stickText;

	// Use this for initialization
	void Start () {

		stickText = transform.GetChild (0).GetComponentInChildren<Text> ();

		isPlayerColliding = false;

	}
	
	// Update is called once per frame
	void Update () {

		checkPlayerCollision ();
		showText ();

	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = true;
		
		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = false;

		}
	}

	public bool checkPlayerCollision()
	{
		return isPlayerColliding;
	}

	public void showText()
	{
		if(isPlayerColliding)
			changeText (stickText,"I");
		else
			changeText (stickText,"");
	}

	public void changeText(Text whichText,string msg)
	{
		whichText.text = msg;
	}

	public void clearStickText()
	{
		stickText.text = "";

	}
}
