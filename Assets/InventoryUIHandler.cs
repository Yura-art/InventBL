using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] ItemsDatabaseSO itemDataBase;

    [SerializeField] GameObject inventoryButton;
    [SerializeField] ScrollRect scrollItems;

    [SerializeField] TextMeshProUGUI previewItemNameText;
    [SerializeField] TextMeshProUGUI previewItemAmountText;
    [SerializeField] Image previewItemImage;
    [SerializeField] CanvasGroup panelItemPreview;

    List<GameObject> InstanciateButtons = new();

    int selectedItemId = -1;

    ItemsFactory factory;

    // Que es esta cochinada
    [SerializeField] PlayerControler player;
    public void Start()
    {
        factory = gameObject.AddComponent<ItemsFactory>();
        factory.InitializeFactory(itemDataBase);

        InstanciateButton();
        SetInventory(inventory);
    }
    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.W)))
        {
            ShowItems();

        }
    }

    public void SetInventory(Inventory newInventory)
    {
        inventory = newInventory;

        inventory.itemUpdated += ShowItems;
        inventory.itemUpdated += UpdatePreviewAmountText;

        inventory.itemAdd += ShowItems;

        inventory.itemRemoved += ShowItems;
        inventory.itemRemoved += HidePreviewPanel;
    }
    public void InstanciateButton()
    {
        for (int i = 0; i < itemDataBase.Items.Count; i++)
        {
            GameObject currentButton = Instantiate(inventoryButton, scrollItems.content);
            currentButton.SetActive(false);
            InstanciateButtons.Add(currentButton);
        }
    }
    public void ShowItems()
    {
        for (int i = 0; i < InstanciateButtons.Count; i++)
        {
            InstanciateButtons[i].SetActive(false);
        }
        foreach (var item in inventory.Items)
        {
            ItemDataSO currenItemData = itemDataBase.SearchById(item.Key);
            GameObject currentButton = InstanciateButtons.Find(x => x.activeSelf == false);
            currentButton.SetActive(true);
            currentButton.transform.Find("Icon").GetComponent<Image>().sprite = currenItemData.Icon;
            currentButton.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            currentButton.GetComponent<Button>().onClick.AddListener(delegate
            {
                ShowSelectedItem(currenItemData, item.Value);
                selectedItemId = item.Key;
            });
        }
    }

    public void ShowSelectedItem(ItemDataSO itemData, int amount)
    {

        ShowPreviewPanel();

        previewItemImage.sprite = itemData.Icon;
        previewItemNameText.text = itemData.ItemName;
        previewItemAmountText.text = amount.ToString();
    }
    public void UpdatePreviewAmountText()
    {
        if (selectedItemId >= 0)
        {
            previewItemAmountText.text = inventory.Items[selectedItemId].ToString();
        }
    }
    public void ShowPreviewPanel()
    {
        panelItemPreview.alpha = 1;
        panelItemPreview.interactable = true;
        panelItemPreview.blocksRaycasts = true;

    }
    public void HidePreviewPanel()
    {
        panelItemPreview.alpha = 0;
        panelItemPreview.interactable = false;
        panelItemPreview.blocksRaycasts = false;

    }
    public void DeleteInventoryItem()
    {
        inventory.RemoveItem(selectedItemId, 1);

        ShowItems();
    }
    public void DropInventoryItem()
    {
        DeleteInventoryItem();
        factory.CreateItem(selectedItemId, Vector3.zero, Quaternion.identity);

    }
    public void UseInventory()
    {
        DeleteInventoryItem();

       ItemDataSO itemData =  itemDataBase.SearchById(selectedItemId);
        
        if (itemData.ItemType == ItemTypeEnum.Weapon)
        {

        }
        else if (itemData.ItemType == ItemTypeEnum.Consumable)
        {

        }
        else if (itemData.ItemType == ItemTypeEnum.Armor) 
        {
            player.Armor.EquipArmor((ArmorItemDataSO)itemData);
        }
    }
}