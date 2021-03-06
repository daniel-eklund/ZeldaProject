using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : Toggler
{
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Obj"))
        {
            this.Change();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.Change();
    }
}