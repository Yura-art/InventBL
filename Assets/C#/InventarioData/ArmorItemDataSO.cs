using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ArmorTypeEnum
{
    head,
    Chest,
    Legs,
    Belt
}
[CreateAssetMenu(fileName = "Armor Item SO", menuName = "Item Data/Items/New Armor Item SO")]
public class ArmorItemDataSO : ItemDataSO
{
    [SerializeField] int _armorValue;
    [SerializeField] ArmorTypeEnum _armorType;

    public ArmorTypeEnum ArmorType { get => _armorType; set => _armorType = value; }
    public int ArmorValue { get => _armorValue; set => _armorValue = value; }
}
