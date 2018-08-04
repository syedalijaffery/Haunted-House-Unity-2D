using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClosetController : MonoBehaviour {

	public bool isHiding;
	bool isGoingOut;

	bool isPlayerColliding;

	Text mainMessage;
	Text closetText;

	Animator closetAnim;

	GameObject character;

	public bool isClicked;

	public Button pause;

	AudioSource closetAudioSource;

	// Use this for initialization
	void Start () {

		isClicked = false;

		isGoingOut = false;



		closetAudioSource = GetComponent<AudioSource> ();

		character = GameObject.Find ("Character");

		closetAnim = GetComponent<Animator> ();

		isHiding = false;
		isPlayerColliding = false;

		mainMessage = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();

		closetText = transform.GetChild (0).GetComponentInChildren<Text>();
		changeText (closetText,"");

	}
	
	// Update is called once per frame
	void Update () {

		if (!FindObjectOfType<GameManagerController> ().isPaused) {
			Closetclose ();
			Hide ();
		}

	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			isClicked = true;
		
	}

	void OnMouseExit()
	{
		isClicked = false;

	}

	void OnTriggerStay2D(Collider2D player)
	{
		if (player.tag == "Player") {
		    
			isPlayerColliding = true;
			changeText (closetText,"Tap To Interact");
			isGoingOut = false;
		      
		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = false;
			changeText (closetText,"");
			isHiding = false;
			isGoingOut = true;
		}
	}

	public void Hide()
	{
		if (isPlayerColliding) {
			if (!isGoingOut && !isHiding && isClicked) {

				pause.enabled = false;
				character.SetActive (false);
				isHiding = !isHiding;
				closetAnim.SetBool ("Open", isHiding);
				closetAudioSource.Play ();
				Invoke ("closeCloset",0.2f);
				isClicked = false;
                isPlayerColliding = false;
				//closetCollider.enabled = false;
							     
			}
			  
		} else {

			if (isHiding) {

				changeText (closetText,"Tap To Interact");

				if (Input.GetKeyDown (KeyCode.I) || isClicked) {
                    
					pause.enabled = true;
					character.SetActive (isHiding);
					closetAnim.SetBool ("Open", isHiding);

					closetAudioSource.Play ();
					Invoke ("closeCloset",0.2f);
                    isPlayerColliding = !isPlayerColliding;
                    isHiding = !isHiding;
                    isClicked = !isClicked;
		
				}


			}

		}
	}

	void closeCloset()
	{
		isHiding = !isHiding;
		closetAnim.SetBool ("Open",isHiding);
		isHiding = !isHiding;
	}

	void Closetclose()
	{
		if (!isHiding) {
			closetAnim.SetBool ("Open",false);
		}
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
