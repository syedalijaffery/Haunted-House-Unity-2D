using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotating : MonoBehaviour {
	private float RotateSpeed = 1f;
	private float Radius;


	private Vector2 _centre;
	private float _angle;

	private void Start()
	{
		_centre = transform.position;
		Radius = Random.Range(4,7);

		//transform.position = Random.insideUnitCircle * 5;
	}

	private void Update()
	{
		

		RotateSpeed = Random.Range (2,5);
		_angle += RotateSpeed * Time.deltaTime;

	
		var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;

		transform.position = _centre + offset;


	}

//	void ChangeRadius(){
//		while (Radius >= 0) {
//
//			Radius -=1;
//	
//		
//		}
//	}

}
