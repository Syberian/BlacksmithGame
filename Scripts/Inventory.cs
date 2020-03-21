using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Configuration;

public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public static event Action<Item> OnItemPickedUp = delegate { };
    public static event Action<int> OnItemUsed = delegate {  };
    public void AddItem(Item itemToAdd)
    {
        if (inventory.Count < 3)
        {
            inventory.Add(itemToAdd);
            OnItemPickedUp?.Invoke(itemToAdd);
        }
        else
        {
            Notifications.Current.Announce("Inventory is full!");
        }
    }

    public void ItemUsed(Item item, int index)
    {
        inventory.Remove(item);
        OnItemUsed?.Invoke(index);
    }
    private void OnDestroy()
    {
        OnItemPickedUp = delegate{  };
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public GameObject mesh;
    public ItemStage itemStage;
}
