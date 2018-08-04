using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerController : MonoBehaviour {

	GameObject restartButton;
	GameObject charaterSelected;

	public bool isPaused;

	// Use this for initialization
	void Start () {

		isPaused = false;

		restartButton = GameObject.Find ("CameraCanvas");
		for (int i = 0; i < restartButton.transform.childCount - 1; i++) {
			if(i != 0 && i < 6)
			restartButton.transform.GetChild (i).gameObject.SetActive (false);
		}

        if (SceneManager.GetActiveScene().name == "DungeonFour")
            restartButton.transform.GetChild(5).gameObject.SetActive(false);

        if (SceneManager.GetActiveScene().name == "DungeonContd")
			restartButton.transform.GetChild (7).gameObject.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {



	}

	public void activateButton()
	{
		activeDiableCanvas (true);
		isPaused = true;
		Time.timeScale = 0;
	}

	public void deathCanvas()
	{
		for (int i = 0; i < restartButton.transform.childCount ; i++) {
			if(i != 0 && i != 2)
				restartButton.transform.GetChild (i).gameObject.SetActive (true);
		}
		restartButton.transform.GetChild (6).gameObject.SetActive (false);
		if(SceneManager.GetActiveScene().name == "DungeonContd")
			restartButton.transform.GetChild (7).gameObject.SetActive (false);

		isPaused = true;
		Time.timeScale = 0;
	}

	public void lastCheckpoint()
	{
		isPaused = false;
		Time.timeScale = 1;
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);

	}

	public void activeDiableCanvas(bool tf)
	{
		for (int i = 0 ; i < restartButton.transform.childCount - 1 ; i++) {
			if(i != 0 && i < 6)
				restartButton.transform.GetChild (i).gameObject.SetActive (tf);
		}

	}

	public void toSelectScreen()
	{
		isPaused = false;
		Time.timeScale = 1;
		SceneManager.LoadScene ("PlayerSelect");
	}

	public void toMainMenuScreen()
	{
		isPaused = false;
		Time.timeScale = 1;
		SceneManager.LoadScene ("MainMenu");
	}

	public void resume()
	{
		FindObjectOfType<MobileMovementCharacter> ().disableEnable (false);
		restartButton = GameObject.Find ("CameraCanvas");
		activeDiableCanvas (false);
		isPaused = false;
		Time.timeScale = 1;
	}

	public void pauseButton()
	{
		isPaused = true;
		FindObjectOfType<MobileMovementCharacter> ().disableEnable (true);
		activeDiableCanvas (true);
		Time.timeScale = 0;
	}

	public void activeRockButton(bool active)
	{
		restartButton.transform.GetChild (7).gameObject.SetActive (active);	
	}
}
