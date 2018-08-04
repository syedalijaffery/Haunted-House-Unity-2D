using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikesController : MonoBehaviour {


	void OnCollisionEnter2D(Collision2D player)
	{
		if (player.gameObject.tag == "Player") {
			
			player.gameObject.GetComponent<Advertisements> ().ShowAd ();
			FindObjectOfType<GameManagerController> ().deathCanvas ();

		}
	}
}
