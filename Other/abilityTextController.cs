using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class abilityTextController : MonoBehaviour {

	public Text abilityText;

	// Use this for initialization
	void Start () {

	

	}
	
	// Update is called once per frame
	void Update () {

		if (FindObjectOfType<CharacterSelectController> ().index == 0)
			abilityText.text = "Special Ability:" + Environment.NewLine + "Moves Faster"; 
		else
			abilityText.text = "Special Ability:" + Environment.NewLine + "More Visibilty";
	}
}
