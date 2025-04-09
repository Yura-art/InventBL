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

    [SerializeField] TextMeshProUGUI previewItemNameText;
    [SerializeField] TextMeshProUGUI previewItemAmountText;
    [SerializeField] Image previewItemImage;
    [SerializeField] CanvasGroup panelItemPreview;

    List<GameObject> instantiatonButtons= new List<GameObject>();
    int selectedItemId;

    ItemFactory factory;

    private void Start()
    {
        factory = gameObject.AddComponent<ItemFactory>();
        factory.InitializeFactory(itemsDatabase);
        factory.CreateItem(0,Vector3.zero,Quaternion.identity);
        //ShowItems();
        InstanciateButton();
        SetInventory(inventory);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ShowItems();
        }
    }

    public void InstanciateButton()
    {
        for (int i = 0; i < itemsDatabase.Items.Count; i++)
        {
            GameObject currenButton = Instantiate(inventoryButton, content);
            currenButton.SetActive(false);
            instantiatonButtons.Add(currenButton);
        }

    }

    public void ShowItems()

    {
        for (int i = 0; i < instantiatonButtons.Count; i++) 
        { 
            instantiatonButtons[i].SetActive(false);
        }   
        foreach (var item in inventory.Items)
        {
            ItemDataSO currentItemData = itemsDatabase.SearchById(item.Key);
            GameObject currenButton = instantiatonButtons.Find( x => x.activeSelf == false);
            currenButton.SetActive(true);
            currenButton.transform.Find("Icon").GetComponent<Image>().sprite = currentItemData.Icon;
            currenButton.transform.Find("Image/Text (TMP)").GetComponent<TextMeshProUGUI>().text = item.Value.ToString();
            currenButton.GetComponent<Button>().onClick.AddListener(delegate
            {
                ShowSelectedItem(currentItemData, item.Value);
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
        //ShowItems();
    }
    public void DropInventoryItem()
    {
        inventory.RemoveItem(selectedItemId, 1);
        factory.CreateItem(selectedItemId, Vector3.zero, Quaternion.identity);
    }
    public void  SetInventory(Inventory newinventory)
    {
        inventory = newinventory;
        inventory.ItemsUpdated += ShowItems;
        inventory.ItemRemoved += ShowItems; 
        inventory.ItemAdded += ShowItems;
        inventory.ItemsUpdated += UpdatePreviewAmountText;
        inventory.ItemRemoved += HidePreviewPanel;
    }
    public void UpdatePreviewAmountText()
    {
        previewItemAmountText.text = inventory.Items[selectedItemId].ToString();
    }
}
