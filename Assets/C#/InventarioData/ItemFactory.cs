using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsFactory : MonoBehaviour
{
    ItemsDatabaseSO database;

    public void InitializeFactory(ItemsDatabaseSO database)
    {
        this.database = database;
    }
    public GameObject CreateItem(int id, Vector3 position, Quaternion rotation, Transform parent = null)
    {
        ItemDataSO itemData = database.SearchById(id);
       GameObject itemGO = Instantiate(itemData.Prefab, position, rotation);
        itemGO.transform.SetParent(parent);
        return itemGO;
    }
}