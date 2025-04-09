using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    ItemsDatabaseSO database;
    public void InitializeFactory(ItemsDatabaseSO database)
    {
        this.database = database;
    }
     public void CreateItem(int id, Vector3 position, Quaternion rotation)
    {
      ItemDataSO itemData =  database.SearchById(id);
        Instantiate(itemData.Prefab, position, rotation);
    }
}
