using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    private Animator animator;
    public GameObject player;
    public GameObject statue;
    private Rigidbody2D srb;
    public CharController cc;
    private BoxCollider2D bc;
    public bool canPush;
    public int dir;
    //1=l,2=u,3=r,4=d,0=all
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        canPush = false;
        player = GameObject.FindGameObjectWithTag("Player");
        cc = player.GetComponent<CharController>();
        animator = player.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        srb = statue.GetComponent<Rigidbody2D>();
        bc = this.GetComponent<BoxCollider2D>();
        //GameObject.FindWithTag("Player").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
    
      
        if (cc.currentState == PlayerState.walk && canPush)
        {
            animator.SetBool("pushing", true);
        } 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //check which side player is on
            canPush = false;
            //on left pushing right
            if (dir == 3 && (player.transform.position.x < this.transform.position.x))
            {
                canPush = true;
                Debug.Log("Can push");
            }
            else if (dir == 1 && (player.transform.position.x > this.transform.position.x))
            {
                canPush = true;
                Debug.Log("Can push");
            }
            else if (dir == 2 && (player.transform.position.y < this.transform.position.y))
            {
                canPush = true;
                Debug.Log("Can push");
            }
            else if (dir == 4 && (player.transform.position.y > this.transform.position.y))
            {
                canPush = true;
                Debug.Log("Can push");
            }
            else if (dir == 0)
            {
                canPush = true;
            }
            if(canPush)
            {
                //turn off statue rb
                if (srb != null)
                {
                    srb.constraints = RigidbodyConstraints2D.None;
                    if (dir == 1 || dir == 3) srb.constraints = RigidbodyConstraints2D.FreezePositionY;
                    if (dir == 2 || dir == 4) srb.constraints = RigidbodyConstraints2D.FreezePositionX;
                    srb.freezeRotation = true;
                }
            } else
            {
                //turn on statue rb
                if (srb != null) srb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
        if (other.CompareTag("OneWay"))
        {
            //remove rigidbody
            //remove collider
            Destroy(bc);
            Destroy(srb);
            canPush = false;
            animator.SetBool("pushing", false);
        }
        if (other.CompareTag("cloud"))
        {
            Destroy(other.gameObject);
            Debug.Log("destroying cloud");
        }
        /*else if (other.CompareTag("attackHitBox"))
        {
            Debug.Log("Attacked object");
        }*/
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("");
            canPush = false;
            animator.SetBool("pushing", false);
        } 
        
    }

}


