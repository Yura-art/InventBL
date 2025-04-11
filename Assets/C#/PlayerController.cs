using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    [SerializeField] List<Item> nearItems = new();
    [SerializeField] ArmorSystem _armor;
    [SerializeField] HealthSystem _health;
    public ArmorSystem Armor { get => _armor; set => _armor = value; }
    public HealthSystem Health { get => _health; set => _health = value; }

    private void Start()
    {
        //inventory = gameObject.AddComponent<Inventory> ();
    }
    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            int itemsAmount = nearItems.Count;
            for (int i = itemsAmount - 1; i >= 0; i--)
            {
                inventory.AddItem(nearItems[i].Id, 1);
                Destroy(nearItems[i].gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            nearItems.Add(item);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Item item))
        {
            nearItems.Remove(item);

        }

    }

}
