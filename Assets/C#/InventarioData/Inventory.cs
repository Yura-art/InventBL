using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void InventoryDatesDelegate();
    public InventoryDatesDelegate itemRemoved;
    public InventoryDatesDelegate itemAdd;
    public InventoryDatesDelegate itemUpdated;
    Dictionary<int, int> _items = new()
    {
        //{0,5},
        //{1,15},
        //{2,1},
    };

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    public void RemoveItem(int id, int amount)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] -= amount;
            if (Items[id] <= 0)
            {
                Items.Remove(id);
                itemRemoved?.Invoke();
            }
            else
            {
                itemUpdated?.Invoke();
            }
        }
    }

    public void AddItem(int ID, int amount)
    {
        if (_items.ContainsKey(ID))
        {
            _items[ID] += amount;
            itemUpdated?.Invoke();

        }
        else
        {
            _items.Add(ID, amount);
            itemUpdated?.Invoke();
        }
        ShowInventory();

    }

    public void ShowInventory()
    {
        foreach (var item in Items)
        {
            Debug.Log("Id" + item.Key + "Cantidad" + item.Value);
        }
    }


}
