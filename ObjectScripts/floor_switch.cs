using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floor_switch : MonoBehaviour
{
    public bool is_pressed;
    public bool canChange;
    public GameObject lockedDoor;
    private SpriteRenderer sr;
    private BoxCollider2D bc;
    public Sprite off;
    public Sprite on;

    // Start is called before the first frame update
    void Start()
    {
        sr = lockedDoor.GetComponent<SpriteRenderer>();
        bc = lockedDoor.GetComponent<BoxCollider2D>();
        is_pressed = false;
        canChange = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("attackBox") || other.CompareTag("cloud"))
        {
            //Debug.Log("Attacked switch");
            if (!is_pressed && canChange)
            {
                //change sprite to off
                //Debug.Log("Turned on");
                this.GetComponent<SpriteRenderer>().sprite = on;
                is_pressed = true;
                sr.enabled = false;
                bc.enabled = false;
                canChange = false;
                StartCoroutine(switchCo());
            } else if (is_pressed && canChange) 
            {
                //change sprite to on
                Debug.Log("Turned off");
                this.GetComponent<SpriteRenderer>().sprite = off;
                is_pressed = false;
                sr.enabled = true;
                bc.enabled = true;
                canChange = false;
                StartCoroutine(switchCo());
            }

        }
    }

    IEnumerator switchCo()
    {
        yield return new WaitForSeconds(.2f);
        canChange = true;
    }



}
