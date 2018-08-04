using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestController : MonoBehaviour {

	public GameObject[] rocks;
	GameObject character;
	public GameObject rockThrow;
	GameObject player;
	public GameObject gameManager;
	public GameObject monster;

	bool isPlayerColliding;
	bool isClicked;
	bool hasInteracted;
	bool outOfRocks = false;
	bool disableInteraction = false;

	Text mainMessage;
	Text chestText;

	int rockNumber;

	// Use this for initialization
	void Start () {

		rockNumber = 0;

		hasInteracted = false;

		isClicked = false;

		isPlayerColliding = false;

		player = GameObject.Find("Character");

		chestText = transform.GetChild (0).GetComponentInChildren<Text>();

		if (PlayerPrefs.GetInt ("monsterDead") == 1) {

			GetComponent<Collider2D> ().enabled = false;

		}
	}
	
	// Update is called once per frame
	void Update () {

		if(!disableInteraction)
		interactionCheck ();

		if (hasInteracted && !outOfRocks && !monster.GetComponent<MonsterController> ().isDead) {
		
			throwRock ();
		
		}
		

		
		

	}

	void OnMouseOver()
	{
		if (Input.GetMouseButtonDown (0) && isPlayerColliding && !hasInteracted) {
			isClicked = true;
			hasInteracted = true;
		}

	}

	void OnMouseExit()
	{
		isClicked = false;
	}

	public void interactionCheck()
	{
		if (isClicked) {
			
			isClicked = !isClicked;
			player.GetComponent<MobileMovementCharacter> ().disableEnable (true);
			gameManager.GetComponent<GameManagerController> ().activeRockButton (true);
			chestText.text = "Rocks Left: " + rocks.Length;
			player.transform.SetPositionAndRotation (new Vector2(transform.position.x - 1.5f,player.transform.position.y),player.transform.rotation);

		} else if (rockNumber > 4 || monster.GetComponent<MonsterController> ().isDead) {

			disableInteraction = true;
			BoxCollider2D[] c = GetComponents<BoxCollider2D> ();
			foreach (BoxCollider2D b in c) {
			
				b.enabled = false;
			
			}
			player.GetComponent<MobileMovementCharacter> ().disableEnable (false);
			gameManager.GetComponent<GameManagerController> ().activeRockButton (false);
			chestText.text = "";

		}
	}

	public void throwRock()
	{
		rocks [rockNumber].SetActive (true);
		if (rocks [rockNumber].GetComponent<rockController> ().isThrown) {
		
			rockNumber++;
			chestText.text = "Rocks Left: " + (rocks.Length - rockNumber);
			if (rockNumber > 4) {
				outOfRocks = true;
			}
		
		}
	}

	void OnTriggerEnter2D(Collider2D player)
	{

		if (player.tag == "Player") {
		
			isPlayerColliding = true;
			chestText.text = "Tap To Throw Rocks"; 
		
		}

	}

	void OnTriggerExit2D(Collider2D player)
	{
		if (player.tag == "Player") {

			isPlayerColliding = false;
			chestText.text = "";
		}
	}
}
