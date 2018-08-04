using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class colliderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D player)
	{
		if (player.tag == "Player") {

			player.GetComponent<MobileMovementCharacter> ().disableEnable(true);
			Invoke ("toContinuePage",2f);

		}
	}

	public void toContinuePage()
	{
		SceneManager.LoadScene ("toBeContinued");
	}
}
