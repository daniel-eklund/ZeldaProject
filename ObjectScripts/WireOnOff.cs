using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireOnOff : MonoBehaviour
{
    public bool is_pressed;
    private Sprite spr;
    public Sprite[] spList;
    public string typeOf;
    public bool changed;

    // Start is called before the first frame update
    void Start()
    {
        is_pressed = false;
        changed = false;
    }

    // Update is called once per frame
    void Update()
    { 
        if (changed)
        {
            //Debug.Log("Changed wires");
            changed = false;
            if (is_pressed)
            {
                TurnOn();
            } else if (!is_pressed)
            {
                TurnOff();
            }
            
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (typeOf == "floorButton")
        {
            if (other.CompareTag("Player") || other.CompareTag("obj") || other.CompareTag("enemy"))
            {
                is_pressed = true;
                changed = true;
            }
        }/*
        if (typeOf == "floorSwitch")
        {
            if ((other.CompareTag("attackBox") || other.CompareTag("cloud")) && is_pressed)
            {
                is_pressed = true;
                changed = true;
            } else if ((other.CompareTag("attackBox") || other.CompareTag("cloud")) && !is_pressed)
            {
                is_pressed = false;
                changed = true;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (typeOf == "floorButton")
        {
            if (other.CompareTag("Player") || other.CompareTag("obj") || other.CompareTag("enemy"))
            {
                is_pressed = false;
                changed = true;
            }
        }
    }*/

    public void TurnOn()
    {
        int i = 0;
        //Array to hold all child obj
        GameObject[] allChildren = new GameObject[transform.childCount];
        //Find all child obj and store to that array
        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }
        //Now turn them all on
        foreach (GameObject child in allChildren)
        {
            switch (child.gameObject.name)
            {
                case "wireUD":
                    spr = spList[10];
                    break;
                case "wireLR":
                    spr = spList[11];
                    break;
                case "wireLE":
                    spr = spList[12];
                    break;
                case "wireRE":
                    spr = spList[13];
                    break;
                case "wireUE":
                    spr = spList[14];
                    break;
                case "wireDE":
                    spr = spList[15];
                    break;
                case "wireTR":
                    spr = spList[16];
                    break;
                case "wireTL":
                    spr = spList[17];
                    break;
                case "wireBR":
                    spr = spList[18];
                    break;
                case "wireBL":
                    spr = spList[19];
                    break;
            }

            child.gameObject.GetComponent<SpriteRenderer>().sprite = spr;
        }
    }
    public void TurnOff()
    {
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
                case "wireUD":
                    spr = spList[0];
                    break;
                case "wireLR":
                    spr = spList[1];
                    break;
                case "wireLE":
                    spr = spList[2];
                    break;
                case "wireRE":
                    spr = spList[3];
                    break;
                case "wireUE":
                    spr = spList[4];
                    break;
                case "wireDE":
                    spr = spList[5];
                    break;
                case "wireTR":
                    spr = spList[6];
                    break;
                case "wireTL":
                    spr = spList[7];
                    break;
                case "wireBR":
                    spr = spList[8];
                    break;
                case "wireBL":
                    spr = spList[9];
                    break;
            }

            child.gameObject.GetComponent<SpriteRenderer>().sprite = spr;
        }
    }
}
