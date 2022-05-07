using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//definition:
//anything that can change state from a toggler
//wires, doors, blocks
//on, off, changed
//sp_list
//type of

public class ToggleAbles : MonoBehaviour
{
    public string typeOf;
    public bool changed;
    public bool on;
    public Sprite[] spList;
    public SpriteRenderer sr;
    public BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        //bool changed = false; 
    }   
}
