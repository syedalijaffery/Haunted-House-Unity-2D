using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleInteractObjects : MonoBehaviour {

	public Text text;

	bool isClicked;

	GameObject currentInterObject;

	bool isPlayerColliding;

	bool isHiding;

	Text mainMessage;

	// Use this for initialization
	void Start () {
		isClicked = false;
		isPlayerColliding = false;
		mainMessage = GameObject.Find("CameraCanvas/MessageText").GetComponent<Text>();
		isHiding = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseOver()
    {
        if (isPlayerColliding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
				InteractWithObject();

            }
        }
    }

    void OnMouseExit()
    {
        isClicked = false;
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
			Debug.Log("Collided with " + player.name);
			currentInterObject = player.gameObject;
			isPlayerColliding = true;
			mainMessage.text = "Tap OBJECT to interact!";

        }
    }

    void OnTriggerExit2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
			currentInterObject = null;
            isPlayerColliding = false;
			mainMessage.text = "";
        }
    }

	void InteractWithObject(){

		if(this.gameObject.name=="Sign"){
			mainMessage.text = "Beware!";
			Invoke("clearMainText", 2f);
		}
		else if(this.gameObject.name=="TombStone"){
			mainMessage.text = "Casper 1996-2018";
			Invoke("clearMainText", 2f);
		}
		else if(this.gameObject.name=="Picture"){
			
		}
		else if(this.gameObject.name=="Cupboard"){
			mainMessage.text = "Why do I hear sounds from the back of this shelf?";
            Invoke("clearMainText", 2f);
		}
		else if(this.gameObject.name=="LockedDoor"){
			mainMessage.text = "Seems like the door is locked!";
            Invoke("clearMainText", 2f);
		}
		else if (this.gameObject.name == "StuckDoor")
        {
            mainMessage.text = "Ugh! The door is stuck!";
            Invoke("clearMainText", 2f);
        }
		else if(this.gameObject.name=="ArrowSign"){
			mainMessage.text = "This is not the end! There is more to come (Evil Laughs)";
            Invoke("clearMainText", 2f);
		}
		else if(this.gameObject.name=="Bed"){
			mainMessage.text = "No time to rest!";
            Invoke("clearMainText", 2f);
		}
		else if (this.gameObject.name == "Window")
        {
            mainMessage.text = "Backyard is really creepy.";
            Invoke("clearMainText", 2f);
        }
		else if(this.gameObject.name=="Bush"){
			if(!checkIsHiding()){
				isHiding = true;
				GameObject.Find("Character").GetComponent<SpriteRenderer>().sortingLayerName = "Background";
				GameObject.Find("Character").GetComponent<MobileMovementCharacter>().disableEnable(true);
				mainMessage.text = "Player is now hiding. You can hide behind the objects!";
				Invoke("clearMainText", 2f);

			}
			else {
				isHiding = false;
				GameObject.Find("Character").GetComponent<SpriteRenderer>().sortingLayerName = "Characters";
                GameObject.Find("Character").GetComponent<MobileMovementCharacter>().disableEnable(false);
			}



		}
	}
	public bool checkIsHiding(){
		return isHiding;
	}
    public void clearMainText()
    {
        mainMessage.text = "";
    }
}
