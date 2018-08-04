using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyPuzzleController : MonoBehaviour {

	Collider2D stickCollider;

	bool isStickInteracted;

	Animator anim;

	Text puzzleText;

	string doorName;

	// Use this for initialization
	void Start () {

		doorName = FindObjectOfType<KeyController> ().doorName;

		isStickInteracted = false;

		anim = GetComponent<Animator> ();

		stickCollider = transform.GetChild (2).GetComponent<Collider2D> ();
		if(PlayerPrefs.HasKey("isInteracableStick"))
		   stickCollider.enabled = false;

		//PlayerPrefs.DeleteAll ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (!PlayerPrefs.HasKey (doorName)) {

			if (checkIfDoorInteracted ())
				dropKey ();
			
		} else {

			anim.SetBool ("isCollide",true);
			anim.SetBool ("isInteracted",true);


		}
	}

	bool checkIfDoorInteracted()
	{
		if (PlayerPrefs.GetString ("isInteracableStick") == "yes" && !isStickInteracted) {

			return stickCollider.enabled = true;

		} else {

			return stickCollider.enabled = false;
		}
	}

	void dropKey()
	{
		bool isPlayerColliding = FindObjectOfType<stickController> ().checkPlayerCollision ();
		if (isPlayerColliding && (Input.GetKeyDown (KeyCode.I) || Input.GetMouseButtonDown (0))) {
		
			isStickInteracted = true;
			anim.SetBool ("isCollide",true);
			stickCollider.enabled = false;
		
		}
	}

}
