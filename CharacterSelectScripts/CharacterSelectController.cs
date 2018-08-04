using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectController : MonoBehaviour {

	public int index;

	int arraySize;

	bool isTapped;

	GameObject isLocked;

	// Use this for initialization
	void Start () {

		isLocked = GameObject.Find ("Canvas/Locked");
		isLocked.SetActive (false);

		isTapped = false;

		index = 0;
		arraySize = transform.childCount;
		Debug.Log (arraySize);


	}
	
	// Update is called once per frame
	void Update () {

		characterSelect ();

	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0))
			isTapped = true;
	}

	void OnMouseExit()
	{
		isTapped = false;
	}

	public void nextCharacter(int num)
	{
		if (num.Equals(1)) {

			transform.GetChild (index).gameObject.SetActive (false);

			if (index < arraySize - 1)
				index++;
			else
				index = 0;

			if (index > PlayerPrefs.GetInt ("characterIndex"))
				isLocked.SetActive (true);
			else
				isLocked.SetActive (false);

			transform.GetChild (index).gameObject.SetActive (true);
		

		} else if (num.Equals(0)) {

			transform.GetChild (index).gameObject.SetActive (false);

			if (index > 0)
				index--;
			else
				index = transform.childCount - 1;

			if (index > PlayerPrefs.GetInt ("characterIndex"))
				isLocked.SetActive (true);
			else
				isLocked.SetActive (false);

			transform.GetChild (index).gameObject.SetActive (true);
		}


	}

	public void characterSelect(){
    
		if (isTapped) {

			isTapped = false;

			if (index <= PlayerPrefs.GetInt ("characterIndex")) {
				
				PlayerPrefs.SetInt ("PlayerSelected",index);
				SceneManager.LoadScene (PlayerPrefs.GetString("checkpoint"));
			}

		}
	
	}



}
