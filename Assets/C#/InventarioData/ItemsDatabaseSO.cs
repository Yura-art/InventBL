using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Items Database SO", menuName = "Item Data/new Items Database SO")]

public class ItemsDatabaseSO : ScriptableObject
{
    [SerializeField] List<ItemDataSO> _items;

    public ItemDataSO SearchById(int id)
    {
        return _items.FirstOrDefault(x=>x.Id == id);
    }
}
