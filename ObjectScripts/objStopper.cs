using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objStopper : MonoBehaviour
{
    public GameObject block;
    public Rigidbody2D bbody;
    // Start is called before the first frame update
    void Start()
    {
        bbody = block.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obj"))
        {
            Destroy(bbody);
        }
    }
}
