using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	public GameObject currentInterObject;
	DoorController door;
	PianoController piano;
	ClosetController closet;
	public Inventory inventory; 
	RaycastHit hit;
	Vector3 touchposition;
	Vector3 GoCenter;
	Vector3 offSet;

	// Use this for initialization
	void Start () {
		inventory = GetComponent<Inventory> ();
		currentInterObject = null;


	
	}

	// Update is called once per frame
	void Update () {
		/*
		if (currentInterObject != null) {

			if (Input.GetMouseButtonDown (0))
				{

				//Debug.Log ("Ray is about to be casted");
				RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

				if(hit.collider != null)
				{
					Debug.Log ("Target Position: " + hit.collider.gameObject.name);

					if (hit.collider.gameObject.name == "Door") {

						currentInterObject.GetComponent<DoorController> ().toNextScene ();

					} else if (hit.collider.gameObject.name == "Closet") {

						currentInterObject.GetComponent<ClosetController> ().Hide ();

					} else if (hit.collider.gameObject.name == "Piano") {
					
						currentInterObject.GetComponent<PianoController> ().checkPianoKey ();

					} else if (hit.collider.gameObject.name == "Mirror") {

						currentInterObject.GetComponent<mirrorCollider> ().checkInteraction ();

					}

				}

				//Debug.DrawRay (Camera.main.transform.position, Camera.main.ScreenPointToRay(Input.mousePosition).direction,Color.red);
				//Debug.Log ("Damn the ray is casted");

//				if (Physics.Raycast(ray, out hit,600000f)){
//					if (hit.collider != null) {
//						if (hit.collider.name == "Door") {
//
//							Debug.Log ("Door Hit");
//						}
//					}
//


//				if(currentInterObject.transform.position == mouse && currentInterObject.name == "Door") {
//					
//						Debug.Log ("Door Please Tap");
//						
//
//				} else if (currentInterObject.transform.position == mouse && currentInterObject.name == "Closet") {
//					
//						
//						Debug.Log ("Interacted with Closet");
//
//				} else if (currentInterObject.transform.position == mouse && currentInterObject.name == "Piano") {
//					
//						Debug.Log ("Interacted with Piano");
//						
//
//
//
//				} else if (currentInterObject.transform.position == mouse && currentInterObject.name == "Door") {
//					
//							
//					}
				
				}
			}*/
		
		}






	void OnTriggerEnter2D(Collider2D other){
	
		if (other.CompareTag ("InteractObject")) {
			currentInterObject = other.gameObject;
//			currentInterObject = GameObject.Find (currentInterObject.name);
			Debug.Log (currentInterObject.name);
		}
	
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject == currentInterObject) {
			currentInterObject = null;


		}
	}

}
