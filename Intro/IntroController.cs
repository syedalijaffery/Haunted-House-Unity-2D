using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour {

	string intro;

	Text introText;

	bool canBeTapped = false;

	// Use this for initialization
	void Start () {

		intro = "A family shifts to an old house near the graveyard. On the very first night some terrible things happen to this family. The boy is left out alone in the dark yard of the old house. He has to figure out a way to break in the house and save his family members from this curse." +
			" Beware of the paranormal activities!" + Environment.NewLine + "(TAP TO CONTINUE) ";

		introText = GetComponent<Text> ();

		StartCoroutine (typeIntro());
	}
	
	// Update is called once per frame
	void Update () {

		if(canBeTapped)
		ifTapped ();

	}

	IEnumerator typeIntro()
	{
		GetComponent<AudioSource> ().Play ();

		for (int i = 0; i < intro.Length; i++) {

			string currenText = intro.Substring (0, i);
			introText.text = currenText;
			yield return new WaitForSeconds (0.06f);

		} 



		GetComponent<AudioSource> ().Stop ();
		canBeTapped = true;

	}

	public void ifTapped()
	{
		if (Input.GetMouseButtonDown (0)) {

			SceneManager.LoadScene ("Front Yard");

		}
	}

	public void SkipIntro(){
		SceneManager.LoadScene("Front Yard");
	}
}
