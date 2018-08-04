using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sisterSaveController : MonoBehaviour {

    bool isPlayerColliding;

    public GameObject mainCamera;
    public GameObject sisterTrapped;
    public GameObject blade;

    GameObject player;

    Text mainText;

    // Use this for initialization
    void Start () {

        player = GameObject.Find("Character");

        mainText = GameObject.Find("CameraCanvas/MessageText").GetComponent<Text>();

        if (PlayerPrefs.GetInt("SisterSaved") == 1)
        {
            GetComponent<Collider2D>().enabled = false;
        }

    }
	
	// Update is called once per frame
	void Update () {

        showCutScene();

	}

    public void showCutScene()
    {
        if (isPlayerColliding)
        {
            StartCoroutine(CutScene());
        }
    }

    IEnumerator CutScene()
    {
        isPlayerColliding = false;

        player.GetComponent<MobileMovementCharacter>().disableEnable(true);

        mainCamera.GetComponent<CamerFollowScript>().changeTarget(sisterTrapped.transform);
        yield return new WaitForSeconds(2f);

        mainCamera.GetComponent<CamerFollowScript>().changeTarget(blade.transform);
        yield return new WaitForSeconds(4f);

        mainCamera.GetComponent<CamerFollowScript>().changeTarget(player.transform);
        mainText.text = "The Blade Is Going To Fall On Sister. (TAP TO CONTINUE)"; 
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => checkMouse());

        mainText.text = "Tap On The Screen To Run Faster. (TAP TO CONTINUE)";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => checkMouse());

        blade.GetComponent<BladeController>().isMoving = true;

        mainText.text = "Tap On The Screen To Run Faster.";

		player.GetComponent<TapScript>().enabled = true;

        GetComponent<Collider2D>().enabled = false;

    }

    void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            isPlayerColliding = true;
        }
    }

    public bool checkMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
