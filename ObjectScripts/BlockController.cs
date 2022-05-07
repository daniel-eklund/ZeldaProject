using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public bool up;
    public bool changed;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public Sprite[] spList;
    public string typeOf;
    //red, blue
    //check up/down bool

    // Start is called before the first frame update
    void Start()
    {
        changed = false;
        sr = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        if (!up) bc.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (changed)
        {
            changed = false;
            if (up) //if down
            {
                up = false;
                //"move up"
                bc.enabled = false;
                switch (typeOf)
                {
                    case "blue":
                        sr.sprite = spList[0];
                        break;
                    case "red":
                        sr.sprite = spList[1];
                        break;
                }
            }
            else
            {
                //else up
                //move down
                up = true;
                bc.enabled = true;
                switch (typeOf)
                {
                    case "blue":
                        sr.sprite = spList[2];
                        break;
                    case "red":
                        sr.sprite = spList[3];
                        break;
                }
            }
        }
    }
}
