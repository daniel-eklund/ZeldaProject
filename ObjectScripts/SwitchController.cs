using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

    public Sprite[] spList;
    public bool On;
    public bool changed;
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        On = false;
        changed = false;
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (changed)
        {
            changed = false;
            if (On)
            {
                On = false;
                //changed sprite
                sr.sprite = spList[0];
                //get all children and set
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

            } else {

                On = true;
                sr.sprite = spList[1];
                //get all children and set
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
                            //Debug.Log("Test On");
                            WireOnOff wr = child.gameObject.GetComponent<WireOnOff>();
                            wr.is_pressed = true;
                            wr.changed = true;
                            break;
                        case "chest":
                            //turn on chest

                            child.SetActive(true);

                            /*var colList = gameObject.GetComponentsInChildren<Collider>();
                            for (var index = 0; index < colList.Length; index++)
                            {
                                colList[index].enabled = true;
                            }*/
                            break;
                        case "FloorBlock":
                            //push down
                            child.gameObject.GetComponent<BlockController>().changed = true;
                            break;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("cloud") || other.CompareTag("attackBox"))
        {
            changed = true;
        }
    }

}
