using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour {

	GameObject rightText,leftText;

	// Use this for initialization
	void Start () {

		rightText = GameObject.Find ("CameraCanvas/RightTutorial");
		rightText.SetActive (false);

		leftText = GameObject.Find ("CameraCanvas/LeftTutorial");
		leftText.SetActive (false);

		PlayerPrefs.SetString ("checkpoint", "Front Yard");

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void showRightTutorial()
	{
		leftText.SetActive (false);
		rightText.SetActive (true);
	}

	public void showleftTutorial()
	{
		leftText.SetActive (true);
		rightText.SetActive (false);
	}

	public void removeTutorial()
	{
		leftText.SetActive (false);
		rightText.SetActive (false);
	}

}
