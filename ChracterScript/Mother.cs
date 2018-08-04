using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour {
	public Light light;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void changeLight() {

		if (Input.GetKeyDown("ability")) {

			if (light.type == LightType.Spot) {

				light.type = LightType.Point;
				light.intensity = 3f;
				light.range = 180f;
			} else {

				light.type = LightType.Spot;
			light.intensity = 5.5f;
			light.range = 281f;
			}
		}

	}
}
