using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakables : MonoBehaviour
{
    /*Note:
    Anim setup:
        -smash [bool parameter] false
        -Default state: idle
        -Transition to -> destroy
            -Conditions: smash = true
        -Transition to -> finished
            -Conditions: animation done
    */
    private Animator anim;
    bool destroy = false;
    bool destroy_from_smash = false;

    //Include a drop table
    //List of spawnawbles i.e. [coin x5, coin x10, heart 0.5, heart 1]
    //List of drop %'s    i.e. [20, 20, 20, 20, 20] (out of 100)

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (!destroy) return;
        if (destroy && anim.GetCurrentAnimatorStateInfo(0).IsName("finished")) {
            destroy_from_smash = true;
            Destroy(this.gameObject);
        } 
    }

    //allows for dropping items etc..
    public void OnDestroy() {
        if (destroy_from_smash) {
            Debug.Log("Dropping some coins");
            //Drop Items / Do things here
        } //else destroying from exit scene
        
    }

    public void Smash()
    {
        //turns off all children, so we can use one animation for destroy
        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
        anim.SetBool("smash", true);
        StartCoroutine(breakCo());
        destroy = true;
    }

    IEnumerator breakCo()
    {
        yield return new WaitForSeconds(.3f);
    }

    //handles weapon collisions that arn't handled in their own class? Fix to allow all weapons under a base class
    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (destroy) return;
        if (other.CompareTag("cloud"))
        {
            this.Smash();
        }
    }*/
}
