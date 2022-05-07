using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    //public Signal setInteract;

    public void TriggerDialog(int s_pos)
    {
        Debug.Log("starting dialog");
        //FindObjectOfType<CharController>().setInteract();
        FindObjectOfType<DialogManager>().StartDialog(dialog, s_pos);
    }
}
