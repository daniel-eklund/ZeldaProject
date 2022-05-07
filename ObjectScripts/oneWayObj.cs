using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayObj : MonoBehaviour
{
    public GameObject oneWay;
    private BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        bc = oneWay.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.CompareTag("Player")) bc.enabled = false;
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
   
    }*/

}


