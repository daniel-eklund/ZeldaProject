using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class under_ledge : MonoBehaviour
{
    public GameObject player;
    public CharacterController cc;
    public Tilemap tilemap;
    public TilemapRenderer tr;

    // Start is called before the first frame update
    void Start()
    {
       GameObject.FindGameObjectWithTag("Player");
       cc = player.GetComponent<CharacterController>();
       tr = tilemap.GetComponent<TilemapRenderer>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (cc.height == 0)
            {
                cc.height = -1;
                //set renderer to off
                tr.enabled = false;
            } else
            {
                cc.height = 0;
                //set renderer to on
                tr.enabled = true;
            }
        }
            
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //cc.height = 0;
            //set renderer to on
            //tr.enabled = true;
        }
    }
}
