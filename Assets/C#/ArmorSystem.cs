using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmorSystem : MonoBehaviour
{
    Dictionary<ArmorTypeEnum, ArmorItemDataSO> _equippedArmor = new();
    ItemsFactory armorFactory;
   [SerializeField] ItemsDatabaseSO _database;

    private void Start()
    {
        armorFactory = gameObject.AddComponent<ItemsFactory>();
        armorFactory.InitializeFactory(_database);
    }
    public ArmorItemDataSO EquipArmor(ArmorItemDataSO armor)
    {
        armorFactory.CreateItem(armor.Id, ,Quaternion.identity);
        ArmorItemDataSO lastItem = null;
        if (!_equippedArmor.ContainsKey(armor.ArmorType))
        {
            _equippedArmor.Add(armor.ArmorType, armor);
            Debug.Log("El jugador se puso en: " +armor.ArmorType + " el item " + armor.ItemName);
        }
        else
        {
            lastItem = _equippedArmor[armor.ArmorType];
            _equippedArmor[armor.ArmorType] = armor;
        }
        return lastItem;    
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
