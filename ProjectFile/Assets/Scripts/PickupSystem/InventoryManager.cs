using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Text ListOfItems;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ShowContent()
    {
        string result = "Inventory Info:" + "\n";
        foreach (var a in Items)
        {
            result += ("Item id: " + a.id + "  ItemName: " + a.itemName + "  Value: " + a.value + "\n");
        }
        ListOfItems.GetComponent<Text>().text = result;
    }

}
