using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggler : MonoBehaviour
{
    public ToggleAbles[] children;
    public string typeOf;
    public bool on;
    public Sprite[] spList;
    public SpriteRenderer sr;
    public BoxCollider2D bc;
    public bool changed;

    // Start is called before the first frame update
    void Start()
    {
        changed = false;
        sr = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        //case for blue/red radio buttons
        if (typeOf == "red") (spList[0], spList[1]) = (spList[2], spList[3]);
    }

    public void Change()
    {
            //loop and change children
            foreach (ToggleAbles child in children)
            {
                child.changed = true;
            }
    }

    public void Draw()
    {
        //change sprites
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

    public IEnumerator switchCo()
    {
        yield return new WaitForSeconds(50f);
    }
}
