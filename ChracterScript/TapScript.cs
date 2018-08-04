using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapScript : MonoBehaviour {

    float movementSpeed = 0f;
    float timeAfterSpeedDecrease = 0.5f;
    float timeLeftToDecrease = 0f;
    float decreaseSpeed = 0.3f;
    
    Animator myAnimator;

	// Use this for initialization
	void Start () {

        myAnimator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        decreasingSpeed();
        increaseSpeed();
        movePlayer();

	}

    public void decreasingSpeed()
    {
        if (movementSpeed > 0)
        {
            if (timeLeftToDecrease >= timeAfterSpeedDecrease)
            {
                if (movementSpeed - decreaseSpeed >= 0)
                {
                    movementSpeed -= decreaseSpeed;
                    myAnimator.SetBool("isDead", false);
                    myAnimator.SetBool("isIdle", false);
                    myAnimator.SetBool("isWalking", true);
                }
                else
                {
                    movementSpeed = 0f;
                    myAnimator.SetBool("isDead", false);
                    myAnimator.SetBool("isIdle", true);
                    myAnimator.SetBool("isWalking", false);
                }
                   

                timeLeftToDecrease = 0f;
            }
            else
            {
                timeLeftToDecrease += 0.1f;
            }
        }
    }

    private void increaseSpeed()
    {
        
		if (Input.GetMouseButtonDown(0) && movementSpeed <= 2f)
        {

            movementSpeed += .75f;

        }

    }

    public void movePlayer()
    {
        transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
    }

}
