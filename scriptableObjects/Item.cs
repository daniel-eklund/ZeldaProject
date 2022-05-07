using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject {
    public Sprite itemSprite;
    public string itemDesc;
    public string type; //name of object
    public bool isKey;
}

