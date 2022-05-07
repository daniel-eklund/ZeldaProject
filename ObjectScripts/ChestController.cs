using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    public bool open;
    public bool changed;

    private SpriteRenderer sr;
    private BoxCollider2D bc;

    public GameObject player;
    private CharController cc;

    public Sprite[] spList;
    public GameObject[] chestContents;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
        changed = false;
        sr = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();

        cc = player.GetComponent<CharController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (changed)
        {
            changed = false;
            if (open)
            {
                //close chest
                open = false;
                sr.sprite = spList[0];
            }
            else
            {
                //open chest
                open = true;
                sr.sprite = spList[1];
            }
        }*/

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("attackBox"))
        {
            changed = true;
            if (!open)
            {
                open = true;
                sr.sprite = spList[1];
                //Get contents
                foreach(GameObject spawn in chestContents)
                {
                    if (spawn.name == "key")
                    {
                        Debug.Log("Key gained!");
                        cc.numKeys++;
                    }
                }
            }
        }
    }

}
