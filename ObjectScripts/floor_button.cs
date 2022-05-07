using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_button : MonoBehaviour
{
    public bool is_pressed = false;
    private SpriteRenderer sr;
    public GameObject lockedDoor;
    private BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        sr = lockedDoor.GetComponent<SpriteRenderer>();
        bc = lockedDoor.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("obj") || other.CompareTag("enemy"))
        {
            //Debug.Log("Item on button");
            is_pressed = true;
            sr.enabled = false;
            bc.enabled = false;
        }
        /*else if (other.CompareTag("attackHitBox"))
        {
            Debug.Log("Attacked object");
        }*/


    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log(" ");
        is_pressed = false;
        sr.enabled = true;
        bc.enabled = true;
    }

}


