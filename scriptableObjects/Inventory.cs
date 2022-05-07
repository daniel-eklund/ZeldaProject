using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject {
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKeys;

    public void AddItem(Item item_add)
    {
        if(item_add.isKey)
        {
            numberOfKeys++;
        } else
        {
            if(!items.Contains(item_add)) {
                items.Add(item_add);
            }
        }
    }
}
