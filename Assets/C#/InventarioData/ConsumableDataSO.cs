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
    [SerializeField] int _consumableValue;
    [SerializeField] ConsumableTypeEnum _consumableType;

    public int value { get => _consumableValue; set => _consumableValue = value; }
    public ConsumableTypeEnum ConsumableType { get => _consumableType; set => _consumableType = value; }
}
