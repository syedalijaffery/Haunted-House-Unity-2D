using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Father : MonoBehaviour {

	public const int maxHealth = 2;
	public int currentHealth = maxHealth;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
		}
	}
}
