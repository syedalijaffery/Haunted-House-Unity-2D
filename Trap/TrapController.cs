using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapController : MonoBehaviour {

    public bool isDead = false;
    bool isFree = false;
    bool isTrapped = true;

    Text mainText;

    Animator anim;

    public GameObject gameManager;
    GameObject character;
	public GameObject blade;
    public GameObject sister;
    public GameObject boySpawnPosition;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

        character = GameObject.Find("Character");

        mainText = GameObject.Find("CameraCanvas/MessageText").GetComponent<Text>();

        if (PlayerPrefs.GetInt("SisterSaved") == 1)
        {
            GetComponent<Collider2D>().enabled = false;
            anim.SetBool("isFree",true);
        }

    }
	
	// Update is called once per frame
	void Update () {

        checkCollision();

	}

    public void checkCollision()
    {
        if (isDead)
        {

            anim.SetBool("isDead", true);
            GetComponent<Collider2D>().enabled = false;
            Invoke("deathCanvas", 2f);

        }
        else if (isFree)
        {

            anim.SetBool("isFree",true);
            GetComponent<Collider2D>().enabled = false;
            blade.GetComponent<BladeController>().isMoving = false;
            character.GetComponent<TapScript>().enabled = false;
            character.GetComponent<Animator>().SetBool("isIdle",true);
            character.GetComponent<Animator>().SetBool("isWalking", false);
            character.GetComponent<Animator>().SetBool("isDead", false);
            character.transform.SetPositionAndRotation(boySpawnPosition.transform.position,character.transform.rotation);
            sister.SetActive(true);

            PlayerPrefs.SetInt("SisterSaved", 1);

            StartCoroutine(CutScene());

        }
    }

    public void deathCanvas()
    {
        gameManager.GetComponent<GameManagerController>().deathCanvas();
        mainText.fontSize = 24;
        mainText.text = "Sister is Dead";
    }

    void OnTriggerEnter2D(Collider2D something)
    {
        if (something.tag == "Player")
        {
            isFree = true;
            isTrapped = false;
            isDead = false;

        }
        else if (something.tag == "Trap")
        {
            isDead = true;
            isFree = false;
            isTrapped = false;
        }
    }

    IEnumerator CutScene()
    {
        isFree = false;

        mainText.text = "Sister: That was close. (TAP TO CONTINUE)";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => checkMouse());

        mainText.text = "We need to get out as soon as possible. (TAP TO CONTINUE)";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => checkMouse());

        sister.SetActive(false);

        mainText.text = "Sister is Unlocked. (TAP TO CONTINUE)";
        yield return new WaitForSeconds(1f);
        yield return new WaitUntil(() => checkMouse());

        mainText.text = "";
        character.GetComponent<MobileMovementCharacter>().disableEnable(false);

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
