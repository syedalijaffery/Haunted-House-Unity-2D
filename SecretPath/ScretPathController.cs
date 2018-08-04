using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScretPathController : MonoBehaviour {

	GameObject door;
	GameObject bookshelf;

	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

		bookshelf = transform.GetChild (0).gameObject;
		door = transform.GetChild (1).gameObject;

		if (!PlayerPrefs.GetString ("isDonePiano").Equals ("yes")) {

			anim.SetBool("isIdle",true);
			door.SetActive (false);

		} else {

			anim.SetBool("isIdle",false);
			door.SetActive (true);

		}

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
