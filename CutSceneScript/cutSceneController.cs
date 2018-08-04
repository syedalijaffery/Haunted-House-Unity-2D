using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cutSceneController : MonoBehaviour {

	public GameObject gameCamera;
	public GameObject monsterCamera;
	public GameObject monsterSpotlight;
	public GameObject monster;
	public GameObject door, door1;

	GameObject character;

	Text mainMessage;

	bool toEnemy = false;

	// Use this for initialization
	void Start () {

		character = GameObject.Find ("Character");

		mainMessage = GameObject.Find ("CameraCanvas/MessageText").GetComponent<Text>();

		if (PlayerPrefs.GetInt ("hasEnteredDungeon") == 1) {

			door1.GetComponent<Collider2D> ().enabled = false;
			door.GetComponent<Animator> ().SetBool ("isOpen",false);
			
		}

		if (PlayerPrefs.GetInt ("monsterDead") == 1) {
		
			monster.SetActive (false);
			monsterCamera.SetActive (false);
			monsterSpotlight.SetActive (false);
			GetComponent<Collider2D> ().enabled = false;
		
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (toEnemy) {

			float cameraWidth = 1.6f;

			PlayerPrefs.SetInt ("hasEnteredDungeon",1);

			door1.GetComponent<Collider2D> ().enabled = false;
			door.GetComponent<Animator> ().SetBool ("isOpen",false);



			if (monster.GetComponent<MonsterController> ().isDead) {

				PlayerPrefs.SetInt ("monsterDead", 1);
				monsterCamera.SetActive (false);

			} else {
				Invoke ("monsterStart",0.5f);
			}



		}

	}


	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {
		
			toEnemy = true;
		
		}
	}

	public void returnCamera()
	{
		toEnemy = false;
		gameCamera.GetComponent<CamerFollowScript> ().changeTarget(character.transform);
		character.GetComponent<MobileMovementCharacter> ().disableEnable (false);

	}

	public bool checkMouse()
	{
		if (Input.GetMouseButtonDown (0)) {
			return true;
		} else {
			return false;
		}
	}

	public void monsterStart()
	{
		monster.GetComponent<MonsterController> ().start = true;

		monsterCamera.SetActive (true);

	}
}
