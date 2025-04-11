using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSystem : MonoBehaviour
{
    Dictionary<ArmorTypeEnum, ArmorItemDataSO> _equippedArmor = new();
    public void EquipArmor(ArmorItemDataSO armor)
    {
        if (!_equippedArmor.ContainsKey(armor.ArmorType))
        {
            _equippedArmor.Add(armor.ArmorType, armor);
        }
        else
        {
            _equippedArmor[armor.ArmorType] = armor;
        }
    }
    public int GetFullArmorValue()
    {
        int value = 0;
        foreach (var item in _equippedArmor)
        {
            value += item.Value.ArmorValue;
        }
        return value;
    }
}
