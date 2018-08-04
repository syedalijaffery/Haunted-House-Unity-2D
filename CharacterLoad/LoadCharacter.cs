using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour {

	GameObject[] character;
	GameObject spawn;
	GameObject characterS;

	// Use this for initialization
	void Awake () {

		//PlayerPrefs.SetInt ("positionIndex",1);

		int index = PlayerPrefs.GetInt ("positionIndex");

		spawn = GameObject.Find ("Spawn" + index);

		character = Resources.LoadAll<GameObject>("");
		characterS = character [PlayerPrefs.GetInt ("PlayerSelected")];
		characterS = Instantiate (characterS, spawn.transform.position, spawn.transform.rotation);
		characterS.name = "Character";
	}

}
