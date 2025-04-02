using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataSO : ScriptableObject
{
    [SerializeField] int _id;
    [SerializeField] string _itemName;
    [SerializeField] Sprite _icon;
    [SerializeField] GameObject _prefab;

    public int Id { get => _id; set => _id = value; }
    public string ItemName { get => _itemName; set => _itemName = value; }
    public Sprite Icon { get => _icon; set => _icon = value; }
    public GameObject Prefab { get => _prefab; set => _prefab = value; }
}
