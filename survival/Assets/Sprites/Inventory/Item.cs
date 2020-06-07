using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Book,
    CreatureCatcher,
    Soda,
    Chocolate
}

public class Item : MonoBehaviour
{
    public ItemType Type;

    public Sprite InventorySprite;

    public int MaxSize;

    public void Use()
    {
        switch (Type)
        {
            case ItemType.Book:
                Debug.Log("Used book");
                break;
            case ItemType.CreatureCatcher:
                Debug.Log("Used creature catcher");
                break;
            case ItemType.Soda:
                Debug.Log("Used soda");
                break;
            case ItemType.Chocolate:
                Debug.Log("Used chocolate");
                break;
            default:
                break;
        }
    }
}
