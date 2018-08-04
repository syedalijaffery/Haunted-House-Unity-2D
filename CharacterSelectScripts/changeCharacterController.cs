using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCharacterController : MonoBehaviour {

	public int goRight;

	bool isClicked;

	// Use this for initialization
	void Start () {

		isClicked = false;

	}

	void Update()
	{
		changeCharacter ();
	}
		
	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0)) {

			isClicked = true;

		}
	}

	void OnMouseExit()
	{
		isClicked = false;
	}

	public void changeCharacter()
	{
		if (isClicked) {

			isClicked = false;   
			FindObjectOfType<CharacterSelectController> ().nextCharacter (goRight);

		}
	}
}
