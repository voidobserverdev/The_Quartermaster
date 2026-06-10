using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
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
    }
}
