using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wires : ToggleAbles
{
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        bc = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (changed)
        {
            changed = false;
            //update sprite
            if (on)
            {
                on = false;
                sr.sprite = spList[1];
            }
            else
            {
                on = true;
                sr.sprite = spList[0];
            }
        }

    }
}
