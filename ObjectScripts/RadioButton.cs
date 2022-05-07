using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioButton : Toggler
{
    void Update() {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("attackBox") || other.CompareTag("cloud"))
        {
            this.Change();
            this.Draw();
        }
    }

    new public void Draw()
    {
        //change sprites
        if (on)
        {
            on = false;
            sr.sprite = spList[1];
            Debug.Log("Radio Draw On");
        }
        else
        {
            on = true;
            sr.sprite = spList[0];
            Debug.Log("Radio Draw Off");
        }
    }
   
}
