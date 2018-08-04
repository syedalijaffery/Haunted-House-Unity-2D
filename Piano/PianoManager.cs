using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PianoManager : MonoBehaviour {

	AudioSource[] pianoKeys;

	public Text[] codeEntered;
	Text mainText;

	int numOfEnteredCode;

	public Button[] button;

	Button backButton;

	// Use this for initialization
	void Start () {

		mainText = GameObject.Find ("Canvas/MainMessage").GetComponent<Text> ();
		mainText.text = "Enter the code in correct order";

		numOfEnteredCode = 0;

		pianoKeys = GetComponents<AudioSource> ();


	}
	
	// Update is called once per frame
	void Update () {

		int check;
		if (numOfEnteredCode == 4) {

			backButton =  GameObject.Find ("Canvas/BackButton").GetComponent<Button>();
			backButton.interactable = false;
			DisableButtons (false);
			numOfEnteredCode = 0;
			check = checkInputs ();
			if (check > 0) {
				
				mainText.text = "Wrong order Played";
				Invoke ("resetInputs", 2f);

                
			} else {
				
				PlayerPrefs.SetString ("checkpoint", "HallWay");
				PlayerPrefs.SetInt ("positionIndex", 3);
				PlayerPrefs.SetString ("isDonePiano","yes");
				mainText.text = "Correct Order Played";
				Invoke ("changeScene",2f);

			}

		}
	}

	public int checkInputs()
	{
		int wrongInputs = 0;
		for (int i = 0; i < 4; i++) {

			if ((PlayerPrefs.GetInt ("code" + i).ToString ()) != codeEntered [i].text)
				wrongInputs++;

		}

		return wrongInputs;
	}

	public void pianoKeyPressed(int index)
	{
		pianoKeys [index].Play ();

		if (numOfEnteredCode <= 3) {
			codeEntered [numOfEnteredCode].text = index.ToString ();

		}

		if(numOfEnteredCode <= 4)
		 numOfEnteredCode++;
	
	}

	public void resetInputs()
	{
		DisableButtons (true);
		mainText.text = "Enter the code in correct order";
		for (int i = 0; i < 4; i++) {
			
			codeEntered [i].text = "";

		}
		backButton.interactable = true;

	}

	public void changeScene()
	{
		SceneManager.LoadScene ("HallWay");
	}

	public void DisableButtons(bool change){
	
		for (int i = 0; i < 7; i++) {

			button [i].enabled = change;

		}
	
	}

	public void deleteCharacter()
	{
		if (numOfEnteredCode > 0 && numOfEnteredCode < 4) {	
			numOfEnteredCode--;
			codeEntered [numOfEnteredCode].text = "";
		}
	}

	public void back()
	{
		PlayerPrefs.SetInt ("positionIndex", 1);
		changeScene ();
	}


}
