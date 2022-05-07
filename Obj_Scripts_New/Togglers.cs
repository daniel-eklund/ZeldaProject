using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Togglers : Objects
{
    public Signal p_signal;
    bool _change = false;
    bool is_colliding = false;
    //0: off, 1: on
    //Raises signal if attacking or cloud enters
    
    void Update() {
        is_colliding = false;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("attackBox") || other.CompareTag("cloud"))
        {
            if (is_colliding) return;
            is_colliding = true;

            if (usable_dir == "left/right") {
                //check for direction and ensure we are on correct side
                //status 0: left, status 1: right
                float tx = other.transform.position.x;
                if (this.transform.position.x > tx && _status == 1) return;
                if (this.transform.position.x < tx && _status == 0) return;
            }
            if (usable_dir == "up/down") {
                //check for direction and ensure we are on correct side
                //status 0: down, status 1: up
                float ty = other.transform.position.y;
                if (this.transform.position.y > ty && _status == 1) return;
                if (this.transform.position.y < ty && _status == 0) return;
            }


            if (_status == 1) {
                Debug.Log("Change to off");
                this.change(0);
                p_signal.Raise();

            } else {
                Debug.Log("Change to on");
                this.change(1);
                p_signal.Raise();

            }
        }   
    }

    /*
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("attackBox") || other.CompareTag("cloud") && _change) {
            //Debug.Log("Exiting");
            other.enabled = true;
            is_colliding = false;
        }
    }*/

}
