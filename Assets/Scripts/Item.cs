using UnityEngine;

public class Item
{
    public string name;
    public int value;
    public ItemCategory category;

    //Constructor
    public Item(string itemName, int itemValue, ItemCategory itemCategory)
    {
        name = itemName;
        value = itemValue;
        category = itemCategory;
    }
}
public enum ItemCategory
{
    Weapon,
    Armor,
    Potion
}
