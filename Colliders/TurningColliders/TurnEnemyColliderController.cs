using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnEnemyColliderController : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D enemy)
	{
		if (enemy.tag == "Enemy") {
		
			FindObjectOfType<ChainsawMan> ().changeDirection();
		
		}
	}


}
