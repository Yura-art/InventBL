using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArmorTypeEnum
{
    Head,
    Chest,
    Legs,
    Belt
}

[CreateAssetMenu(fileName = "Armor Item SO", menuName = "Item Data/Items/New Armor Item SO")]


public class ArmorItemDataSO : ItemDataSO
{
    [SerializeField] int _value;
    [SerializeField] ArmorTypeEnum _type;
}
