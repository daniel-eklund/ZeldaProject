using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public int _status; //holds status of object, int to correspond with spList
    public Sprite[] spList; //list of sprites, only 1 if sprite doesn't update on status
    private SpriteRenderer sr;
    private BoxCollider2D bc;

    [SerializeField]
    public string usable_dir; //null, left/right, up/down, block (doors, blocks, etc)
    [SerializeField]
    public int _default;

    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        bc = this.GetComponent<BoxCollider2D>();
        _status = _default;
        this.updateSprite();
        if (usable_dir == "block" && _status == 0) bc.enabled = false;
    }

    //dependants need to implement Raised, otherwise nothing.
    public void Raised() {}

    //change sprites based on status
    public void updateSprite()
    {
        sr.sprite = spList[_status];
    }

    //change status and sprite, togg to turn off box collider (doors)
    public void change(int sc, int togg = -1) {
        _status = sc;
        this.updateSprite();
        if (togg > -1) this.toggleCollider(togg);
    }

    //kill self here
    public void kill() {
        Destroy(this.gameObject);
    }

    public void toggleCollider(int t) { //0 is off, 1 is on
        if (t == 1) { 
            this.bc.enabled = true;
        } else {
            this.bc.enabled = false;
        }
    }

    public IEnumerator switchCo()
    {
        yield return new WaitForSeconds(0.3f);
    }
}
