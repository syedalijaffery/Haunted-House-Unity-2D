using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class closetTrappedController : MonoBehaviour {

	bool isClicked;
	bool isPlayerColliding;
	bool isClosetLocked;
	bool inCoroutine = false;
	bool mouseButton = false;

	Animator anim;

	AudioSource[] allSource;

	public GameObject father;
	public GameObject characterMove;

	BoxCollider2D closetCollider;

	Text mainMessage;
	Text closetText;

	// Use this for initialization
	void Start () {

		allSource = GetComponents<AudioSource> ();

		anim = GetComponent<Animator> ();

		mainMessage = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();
		closetText =  transform.GetChild (0).GetComponentInChildren<Text>();

		isClicked = false;
		isPlayerColliding = false;

		if (PlayerPrefs.GetInt ("SisterCloset") == 0) {

			isClosetLocked = true;

		} else if (PlayerPrefs.GetInt ("SisterCloset") == 1) {

			isClosetLocked = false;
		} else {

			allSource [0].Stop ();
			GetComponent<Collider2D> ().enabled = false;
			transform.GetChild (1).gameObject.SetActive (false);
			anim.SetBool ("isOpen", true);

		}



	}
	
	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt ("SisterCloset") <= 1) {

			interact ();
			if (inCoroutine)
				checkMouse ();
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

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {
			closetText.text = "Tap to interact";
			isPlayerColliding = true;
		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {
			closetText.text = "";
			isPlayerColliding = false;
		}
	}

	public void interact()
	{
		

		if (isClicked) {

			if (isClosetLocked) {

				isClicked = false;
				changeText (mainMessage, "There is someone inside! Need to find the key");
				Invoke ("cleartext", 5f);

			} else {


				isClicked = false;
				GetComponent<Collider2D> ().enabled = false;
				FindObjectOfType<MobileMovementCharacter> ().disableEnable (true);
				transform.GetChild (1).gameObject.SetActive (false);
				GetComponent<AudioSource> ().Stop (); 
				anim.SetBool ("isOpen", true);
				allSource [1].Play ();

				FindObjectOfType<MobileMovementCharacter> ().moveTo (characterMove);
				father.SetActive (true);
				GameObject.FindGameObjectWithTag("Trap").GetComponent<BladeController>().isMoving = true;
				StartCoroutine (waitForInput("Dad:Thank God! Are you alright Casper? (TAP TO CONTINUE)"));

				PlayerPrefs.SetInt ("characterIndex",1);

				PlayerPrefs.SetString ("pianoKeyMissing", "false");

				PlayerPrefs.SetInt ("SisterCloset", 2);


	
			}

		}


	}

	public void changeText(Text text,string s)
	{ 
		text.text = s;
	}

	public void cleartext()
	{
		mainMessage.text = "";
	}

	public void timer(float till)
	{
		float time = 0;
		while (time <= till)
			time += Time.deltaTime;
		
	}

	IEnumerator waitForInput(string s)
	{
		inCoroutine = true;
		
		mainMessage.text = s;

		yield return new WaitForSeconds (1f);
		yield return new WaitUntil(() => checkMouse());

		mouseButton = false;

		mainMessage.text = "Casper: I'm fine dad! I am glad you're alive! (Tap To Continue)";

		yield return new WaitForSeconds (1f);
		yield return new WaitUntil(() => checkMouse());

		mouseButton = false;

		mainMessage.text = "Dad: We should hurry and save others! (Tap To Continue)";

		yield return new WaitForSeconds (1f);
		yield return new WaitUntil(() => checkMouse());

		mouseButton = false;

		mainMessage.text = "Dad: Found this piano key in the closet. Might be of some help. (Tap To Continue)";

		yield return new WaitForSeconds (1f);
		yield return new WaitUntil(() => checkMouse());

		mouseButton = false;

		mainMessage.text = "";

		Invoke ("disappearCharacter",1f);

		mainMessage.text = "You have unlocked Father! (Tap To Continue)";
		yield return new WaitForSeconds (1f);
		yield return new WaitUntil(() => checkMouse());
		mainMessage.text = "You can now select unlocked characters from the Select Character Screen (Tap To Continue)";
		yield return new WaitForSeconds (1f);
		yield return new WaitUntil(() => checkMouse());

		mainMessage.text = "";
		FindObjectOfType<MobileMovementCharacter> ().disableEnable (false);


	}

	public void disappearCharacter()
	{

		father.SetActive (false);

	}

	public bool checkMouse()
	{
		if (Input.GetMouseButtonDown (0)) {
			return true;
		} else {
			return false;
		}
	}

}
