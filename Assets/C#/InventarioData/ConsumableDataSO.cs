using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableTypeEnum
{
    Heal,
    Poison
}

[CreateAssetMenu(fileName = "Consumable Item SO", menuName = "Item Data/Items/New Consumable Item SO")]

public class ConsumableDataSO : ItemDataSO
{
    [Header("Consumable Data")]

    [SerializeField] int _value;
    [SerializeField] ConsumableTypeEnum _type;
}
