using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    Dictionary<int, int> _items = new()
    {
        {1,8},
        {5,8},
        {2,8},
    };

    public Dictionary<int, int> Items { get => _items; set => _items = value; }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    AddItem(0, 1);
        //}

        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    AddItem(1, 1);
        //}

        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    AddItem(2, 1);
        //}

    }

    public void AddItem(int id , int amount)
    {
        if (Items.ContainsKey(id))
        {
            Items[id] = amount;
        }

        else
        {
            Items.Add(id, amount);
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
