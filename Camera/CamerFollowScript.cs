using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerFollowScript : MonoBehaviour {

    public Transform target;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;

    public float YMaxValue;

    public float YMinValue;

    public float XMaxValue;

    public float XMinValue;

	Vector3 startPosition;

	void Start()
	{
		float index = PlayerPrefs.GetInt ("positionIndex");

		if (index < 3  && PlayerPrefs.GetInt("positionIndex") != 0) {
			
				startPosition = GameObject.Find ("Spawn" + index).transform.position;
				transform.SetPositionAndRotation (new Vector3 (startPosition.x, startPosition.y, transform.position.z), Quaternion.Euler (0, 0, 0));

		}


		target = GameObject.Find ("Character").transform;
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPos = target.position;

		targetPos.y = Mathf.Clamp (target.position.y,YMinValue,YMaxValue);

        targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);

        targetPos.z = transform.position.z;

         transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
	}

	public void changeTarget(Transform newTarget)
	{
		target = newTarget;
	}
}
