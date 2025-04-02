using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Item SO", menuName = "Item Data/Items/New Weapon Item SO")]


public class WeaponItemDataSo : ItemDataSO
{
    [Header("Weapon Data")]

    [SerializeField] int _damage;
}
