using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool is_pressed;
    public bool changed;
    private SpriteRenderer sr;
    public Sprite[] spList;

    ////////////////////////////////
    //NEED TO FIX 
    //interaction with doors
    ///////////////////////////////


    // Start is called before the first frame update
    void Start()
    {
        is_pressed = false;
        changed = false;
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("obj") || other.CompareTag("enemy"))
        {
            sr.sprite = spList[1];
            //Debug.Log("Item on button");
            is_pressed = true;
            changed = true;
            //turn on
            int i = 0;
            //Array to hold all child obj
            GameObject[] allChildren = new GameObject[transform.childCount];
            //Find all child obj and store to that array
            foreach (Transform child in transform)
            {
                allChildren[i] = child.gameObject;
                i += 1;
            }
            //Now turn them all off
            foreach (GameObject child in allChildren)
            {
                switch (child.gameObject.name)
                {
                    case "door":
                        //DoorController script = 
                        child.gameObject.GetComponent<DoorController>().changed = true;
                        //script.changed = true;            
                        break;
                    case "WireObj":
                        //Debug.Log("Test Off");
                        WireOnOff wr = child.gameObject.GetComponent<WireOnOff>();
                        wr.is_pressed = true;
                        wr.changed = true;
                        break;
                    case "FloorBlock":
                        //push down
                        child.gameObject.GetComponent<BlockController>().changed = true;
                        break;
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //turn off
        //Debug.Log(" ");
        sr.sprite = spList[0];
        is_pressed = false;
        changed = true;

        int i = 0;
        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];
        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        //Now turn them all off
        foreach (GameObject child in allChildren)
        {
            switch (child.gameObject.name)
            {
                case "door":
                    //DoorController script = 
                    child.gameObject.GetComponent<DoorController>().changed = true;
                    //script.changed = true;            
                    break;
                case "WireObj":
                    //Debug.Log("Test Off");
                    WireOnOff wr = child.gameObject.GetComponent<WireOnOff>();
                    wr.is_pressed = false;
                    wr.changed = true;
                    break;
                case "FloorBlock":
                    //push down
                    child.gameObject.GetComponent<BlockController>().changed = true;
                    break;
            }
        }
    }
}
