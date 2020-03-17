using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
    
public class Inventory : MonoBehaviour
{
    public List<Item> inventory = new List<Item>();
    public static event Action<Item> OnItemPickedUp = delegate { };
    public void AddItem(Item itemToAdd)
    {
        if (inventory.Count < 3)
        {
            inventory.Add(itemToAdd);
            OnItemPickedUp?.Invoke(itemToAdd);
        }
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
    public Mesh mesh;
}
