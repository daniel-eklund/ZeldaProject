using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pushBounds : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            rb.constraints = RigidbodyConstraints2D.None;
        }
    }

}

