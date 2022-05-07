using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Objects;

public class Toggle_Obj : Objects
{    
    [SerializeField]
    public Objects[] child_list;

    [SerializeField]
    public int[] status_list; //status match to open
    //example: [1, 0, 1]
    //this means switch 1 is on, 2 is off, and 3 is on to change

    //check child_list after each onPressed signal

    //0: open, 1: closed

    new public void Raised() {
        //Debug.Log("Raised");
        bool _change = true;
        for (int i=0; i < child_list.Length; ++i) {
            if (child_list[i]._status != status_list[i]) _change = false;
        }

        if (_change) {
            if (this._status == 0) { //if open, close
                //Debug.Log("Closing");
                this._status = 1;
                this.change(1, 1); 
            } else { //if close, open
                //Debug.Log("Opening");
                this._status = 0;
                this.change(0, 0); 
            }
        } else { //keep it at default. ex: button is 'unpushed' -> resets
            this._status = this._default;
            this.change(this._status, this._default); 
        }

    }

}
