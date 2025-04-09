using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataSO : ScriptableObject
{
    public enum ItemTypeEnum
    {
        Armor,
        Consumable,
        Weapon
    }
    [SerializeField] int _id;
    [SerializeField] string _itemName;
    [SerializeField] Sprite _icon;
    [SerializeField] GameObject _prefab;
    [SerializeField] ItemTypeEnum _itemType;

    public int Id { get => _id; set => _id = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public GameObject Prefab { get => _prefab; set => _prefab = value; }
    public ItemTypeEnum ItemType { get => _itemType; set => _itemType = value; }
}
