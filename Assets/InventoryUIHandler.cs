using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemsDatabaseSO itemsDatabase;

    [SerializeField] GameObject inventoryButton;
    [SerializeField] Transform content;

    private void Start()
    {
        ShowItems();
    }

    public void ShowItems()
    {
        foreach(var item in inventory.Items)
        {
            ItemDataSO currentItemData = itemsDatabase.SearchById(item.Key);
            GameObject currenButton = Instantiate(inventoryButton, content);
            currenButton.transform.Find("Icon").GetComponent<Image>().sprite = currentItemData.Icon; 
            currenButton.transform.Find("Image/Text (TMP)").GetComponent<TextMeshProUGUI>().text = item.Value.ToString(); 
        }
    }
}
