using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class specialAbilityController : MonoBehaviour {

	GameObject spotLight;

	// Use this for initialization
	void Start () {

		spotLight = GameObject.Find ("PlayerSpotlight");

		if (PlayerPrefs.GetInt ("PlayerSelected") == 1)
			spotLight.GetComponent<Light> ().spotAngle = 85;
		else
			spotLight.GetComponent<Light> ().spotAngle = 65;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
