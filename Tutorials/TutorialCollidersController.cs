using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCollidersController : MonoBehaviour {

	public string colliderType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {

			if (colliderType == "left")
				FindObjectOfType<TutorialController> ().showleftTutorial();
			else if(colliderType == "right")
				FindObjectOfType<TutorialController> ().showRightTutorial();
			else
				FindObjectOfType<TutorialController> ().removeTutorial();

		}

	}
		
}
