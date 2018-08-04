using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class DragDropKey : MonoBehaviour
{
	GameObject currentInterObject;
	private float time;
	float currentTime;


	public Text Timer;

	float rand;
	bool win;

	Text timeRemaining;
	Text mainMessage;

	void Start(){

		//currentInterScript = currentInterObject.GetComponent<InteractionObject> ();
		timeRemaining = GameObject.Find("Canvas/Text").GetComponent<Text>();
		currentInterObject = null;
		time = getSeconds();
		win = false;

		if (!PlayerPrefs.HasKey ("TubTimer")) {

			PlayerPrefs.SetFloat ("TubTimer",0);

		}
	

	}

	void Update() {

		PlayerPrefs.SetFloat ("TubTimer", PlayerPrefs.GetFloat ("TubTimer") + Time.deltaTime);

		if (currentInterObject != null) {
			
			currentTime = getSeconds();
			currentTime = currentTime - time;



			if (currentTime >= rand) {
				
				win = true;
			}

			if (!win) {
				TimeRemaining ();

			} else if (win == true) {

				PlayerPrefs.SetString ("checkpoint", "Bathroom");
				PlayerPrefs.SetInt ("positionIndex", 2);
				PlayerPrefs.SetInt ("SisterCloset", 1);
				timeRemaining.text = "You now have the Key!";

                //				if (currentInterScript.inventory) {
                //				
                //					inventory.AddItem (currentInterObject.gameObject);
                //				}
                currentInterObject.SetActive(false);
				Invoke ("changeScene",1f);
			}

		}

	}

	void OnMouseDrag(){

		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 10);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		transform.position = objPosition;
	}

	void TimeRemaining(){
		
		float t = rand - currentTime;
		int tim =  Mathf.RoundToInt(t);
		timeRemaining.text ="Time remaining to get the key: " + tim.ToString ();


    }

	//Function for getting current time
	float getSeconds()
	{
		return float.Parse(DateTime.Now.Second.ToString()) + (float.Parse(DateTime.Now.Hour.ToString()) * 60 * 60) + (float.Parse(DateTime.Now.Minute.ToString()) * 60) ;
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Key") {

			rand = UnityEngine.Random.Range (7f, 10f);
			//Debug.Log("Time Collision" + (Time.time - time));
			currentInterObject = other.gameObject;
			//currentInterObject = GameObject.Find(currentInterObject.name);
			Debug.Log (currentInterObject.name);
		}

	}
	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject == currentInterObject) {
			if(!win)
			timeRemaining.text = "Drag the hand on the key to get it!";
			time = getSeconds();
			currentInterObject = null;

		}
	}

	void changeScene()
	{
		
		SceneManager.LoadScene ("bathroom"); 

	}
}