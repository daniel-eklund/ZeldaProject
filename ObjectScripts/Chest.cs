using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : Interactable
{
    public Item contents;
    public Inventory p_Inventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("attack") && playerInRange)
        {
            if(!isOpen)
            {
                //Open the chest
                OpenChest();
            } else
            {
                //Chest is already open
                ChestIsOpen();
            }
        }
    }

    public void OpenChest()
    {

        //Dialog window on
        dialogBox.SetActive(true);
        //Dialog text = contents text
        dialogText.text = contents.itemDesc;
        //add item to inventory
        p_Inventory.AddItem(contents);
        p_Inventory.currentItem = contents;
        //raise signal to player to animate correctly
        raiseItem.Raise();
        //raise the context clue
        contextOn.Raise();
        //set the chest to open
        isOpen = true;
        anim.SetBool("opened", true);
    }

    public void ChestIsOpen()
    {
        // Turn dialog off
        dialogBox.SetActive(false);
        contextOff.Raise();
        // raise the signal to the player to stop animating
        raiseItem.Raise();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            //Debug.Log("Player in range.");
            contextOn.Raise();
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            //Debug.Log("");
            contextOff.Raise();
            playerInRange = false;
        }
    }

}
