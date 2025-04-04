using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void InventoryUpdateDelegate();
    public InventoryUpdateDelegate ItemRemoved;
    public InventoryUpdateDelegate ItemAdded;
    public InventoryUpdateDelegate ItemsUpdated;

    Dictionary<int, int> _items = new()
    {
        {1,8},
        {5,8},
        {2,8},
    };

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    private void Update()
    {



        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    RemoveItem();
        //}

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    AddItem(2, 1);
        //}

    }
    public void RemoveItem(int id , int amount )
    {
        if (Items.ContainsKey(id)) 
        { 
            Items[id] -= amount;

            if (Items[id] <= 0)
            {
                Items.Remove(id);
                ItemRemoved?.Invoke();
            }
            else
            {
                ItemsUpdated?.Invoke();
            }
        }
    }

    public void AddItem(int id , int amount)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] = amount;
            ItemsUpdated?.Invoke();
        }

        else
        {
            Items.Add(id, amount);
            ItemAdded?.Invoke();
        }

        ShowInventory();
    }

    public void ShowInventory()
    {
        foreach (var item in Items)
        {
            Debug.Log("Id" + item.Key + " cantidad " + item.Value);
        }
    }
}
