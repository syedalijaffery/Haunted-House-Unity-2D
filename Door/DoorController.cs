using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour {

	public AudioClip door;

	public bool isDoorLocked;

	public string nextScene;

	public Text mainMessage;

	Text doorText;

	public string doorName;

	bool isPlayerColliding;

	public int indexPosition;

	Vector3 position;

	bool isClicked;

	public LoadingScreen loadingScreen;

	// Use this for initialization
	void Start () {

		isClicked = false;

		mainMessage = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();

		doorText = transform.GetChild (0).GetComponentInChildren<Text>();

		isPlayerColliding = false;

		changeText (doorText,"");

	}
	
	// Update is called once per frame
	void Update () {

		toNextScene ();
		
	}

	void OnMouseOver()
	{
		if (isPlayerColliding) {
			if (Input.GetMouseButtonDown (0)) {
				isClicked = true;
			}
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
			changeText (doorText,"Tap Door To Enter!");
		}
	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = false;
			changeText (doorText,"");
		}
	}

	public void toNextScene()
	{
		//if (isPlayerColliding) {	
			if (!isDoorLocked && (Input.GetKeyDown (KeyCode.I) || isClicked)) {
				int sceneNum = 0;
				PlayerPrefs.SetInt ("positionIndex", indexPosition);
				PlayerPrefs.SetString ("checkpoint", nextScene);
				SceneManager.LoadScene (nextScene);
		
			//}
		} else if(isDoorLocked )
		{
				
			Debug.Log ("Door Locked!");
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



}
