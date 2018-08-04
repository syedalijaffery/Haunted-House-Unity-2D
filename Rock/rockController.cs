﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rockController : MonoBehaviour {

	public Rigidbody2D rb;
	public Rigidbody2D hook;

	public float releaseTime = .15f;
	public float maxDragDistance = 2f;

	public GameObject nextBall;

	private bool isPressed = false;
	public bool isThrown = false;

	void Update ()
	{
		if (isPressed)
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			if (Vector3.Distance(mousePos, hook.position) > maxDragDistance)
				rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
			else
				rb.position = mousePos;
		}
	}

	void OnMouseDown ()
	{
		isPressed = true;
		rb.isKinematic = true;
	}

	void OnMouseUp ()
	{
		isPressed = false;
		rb.isKinematic = false;

		StartCoroutine(Release());
	}

	IEnumerator Release ()
	{
		yield return new WaitForSeconds(releaseTime);

		isThrown = true;

		GetComponent<SpringJoint2D>().enabled = false;
		this.enabled = false;

		yield return new WaitForSeconds(0.3f);
		this.enabled = false;


		if (nextBall != null)
		{
			nextBall.SetActive(true);
		} else
		{
			Enemy.EnemiesAlive = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

	}

	void OnTriggerEnter2D(Collider2D enemy)
	{
		if (enemy.tag == "Enemy" && isThrown) {

			enemy.GetComponent<MonsterController> ().decreaseHealth ();

		}
	}

}

