using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemSlot;
    [SerializeField] Transform inventoryContainer;
    [SerializeField] Button generateItemButton;
    [SerializeField] Button filterWeapon;
    [SerializeField] Button filterArmor;
    [SerializeField] Button filterPotion;
    [SerializeField] Button showAllItems;
    public List<Item> playerInventory = new List<Item>(); // can simply use new()

    void Start()
    {
        generateItemButton.onClick.AddListener(() =>
        {
            GenerateRandomItem();
            Debug.Log(playerInventory.Count);
        });
        filterArmor.onClick.AddListener(() =>
        {
            FilterInventory(ItemCategory.Armor);
        });
        filterWeapon.onClick.AddListener(() =>
        {
            FilterInventory(ItemCategory.Weapon);
        });
        filterPotion.onClick.AddListener(() =>
        {
            FilterInventory(ItemCategory.Potion);
        });
        showAllItems.onClick.AddListener(() =>
       {
           RefreshUI();
       });
    }

    void GenerateRandomItem()
    {
        int enumLength = System.Enum.GetValues(typeof(ItemCategory)).Length;

        int randomCategory = Random.Range(0, enumLength);
        int randomValue = Random.Range(1, 100);

        ItemCategory generatedCategory = (ItemCategory)randomCategory;

        Item item = new Item(generatedCategory.ToString(), randomValue, generatedCategory);

        playerInventory.Add(item);

        RefreshUI();
    }

    void RefreshUI()
    {
        foreach (Transform item in inventoryContainer)
        {
            Destroy(item.gameObject);
        }

        foreach (Item item in playerInventory)
        {
            TextMeshProUGUI spawnedItem = Instantiate(itemSlot, inventoryContainer);
            spawnedItem.text = $"{item.name}-{item.category}-{item.value}g";
        }
    }

    void FilterInventory(ItemCategory filterCategory)
    {
        foreach (Transform item in inventoryContainer)
        {
            Destroy(item.gameObject);
        }
        foreach (Item item in playerInventory)
        {
            if (filterCategory == item.category)
            {
                TextMeshProUGUI spawnedItem = Instantiate(itemSlot, inventoryContainer);
                spawnedItem.text = $"{item.name}-{item.category}-{item.value}g";
            }
        }
    }
}
