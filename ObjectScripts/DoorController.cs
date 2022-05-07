using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public bool closed;
    public bool changed;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public Sprite[] spList;
    public string typeOf;
    //doorL, doorR, doorU, doorD
    //rename object to door
    
    // Start is called before the first frame update
    void Start()
    {
        //closed = true;
        changed = false;
        sr = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        if (!closed) bc.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (changed)
        {
            changed = false;
            //flip door
            //if closed == true: shut
            //closed == false: open
            if (!closed)
            {
                closed = true;
                //open
                //turn on sprite renderer
                sr.enabled = true;
                bc.enabled = true;
                //turn on colliders
                //grab door type
                switch (typeOf)
                {
                    case "doorD":
                        sr.sprite = spList[0];
                        break;
                    case "doorU":
                        sr.sprite = spList[1];
                        break;
                    case "doorL":
                        sr.sprite = spList[3];
                        break;
                    case "doorR":
                        sr.sprite = spList[2];
                        break;
                }
            } else
            {
                //close
                closed = false;
                sr.enabled = false;
                bc.enabled = false;
                //turn off sprite renderer
                //turn off colliders
            }
        }
    }
}
