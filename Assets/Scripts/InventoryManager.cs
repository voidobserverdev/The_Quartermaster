using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI itemSlot;
    [SerializeField] Transform inventoryContainer;
    [SerializeField] Button button;
    public List<Item> playerInventory = new List<Item>(); // can simply use new()

    void Start()
    {
        button.onClick.AddListener(() =>
        {
            GenerateRandomItem();
            Debug.Log(playerInventory.Count);
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
}
