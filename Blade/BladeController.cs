using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeController : MonoBehaviour {

    public bool isMoving = false;
	
	// Update is called once per frame
	void Update () {

        if (isMoving)
        {
            transform.Translate(Vector2.down * 0.725f * Time.deltaTime);
        }

	}
}
