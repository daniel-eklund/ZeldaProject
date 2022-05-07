using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockDoor : MonoBehaviour
{
    public GameObject player;
    public CharController cc;
    // Start is called before the first frame update
    void Start()
    {
        cc = player.GetComponent<CharController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && (cc.numKeys > 0))
        {
            cc.numKeys--;
            this.gameObject.SetActive(false);
        }
    }
}
