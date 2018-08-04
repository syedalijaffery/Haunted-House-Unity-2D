using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class toBeContinuedController : MonoBehaviour {

	string intro;

	Text introText;

	bool canBeTapped = false;

	// Use this for initialization
	void Start () {

		intro = "AND SURVIVE ";

		introText = GetComponent<Text> ();

		StartCoroutine (typeIntro());
	}

	// Update is called once per frame
	void Update () {


	}

	IEnumerator typeIntro()
	{
		GetComponent<AudioSource> ().Play ();

		for (int i = 0; i < intro.Length; i++) {

			string currenText = intro.Substring (0, i);
			introText.text = currenText;
			yield return new WaitForSeconds (0.15f);

		} 



		GetComponent<AudioSource> ().Stop ();

	}


}
