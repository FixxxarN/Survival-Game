using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Book,
    CreatureCatcher,
    Soda,
    Chocolate,
    GrassBlock,
    DirtBlock,
    StoneBlock,
    CoalBlock,
    IronBlock,
    Gun
}

public enum ItemQuality
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public class Item : MonoBehaviour
{
    public int Id;

    public ItemType Type;

    public bool CanBeUsed;

    public bool CanBeEquipped;

    public ItemQuality Quality;

    public Sprite InventorySprite;

    public Sprite Sprite;

    public int MaxSize;

    public float Strength, Intellect, Agility, Stamina, Thirst;

    public string ItemName;

    public string Description;

    public float PositionX;

    public float PositionY;

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

    public string GetTooltip()
    {
        string stats = string.Empty;
        string color = string.Empty;
        string newLine = string.Empty;

        if(Description != string.Empty)
        {
            newLine = "\n";
        }

        switch (Quality)
        {
            case ItemQuality.Common:
                color = "White";
                break;
            case ItemQuality.Uncommon:
                color = "Lime";
                break;
            case ItemQuality.Rare:
                color = "Purple";
                break;
            case ItemQuality.Epic:
                color = "Magenta";
                break;
            case ItemQuality.Legendary:
                color = "Orange";
                break;
            default:
                break;
        }

        if(Strength > 0)
        {
            stats += "\n+" + Strength.ToString() + " Strength";
        }
        if (Intellect > 0)
        {
            stats += "\n+" + Intellect.ToString() + " Intellect";
        }
        if (Agility > 0)
        {
            stats += "\n+" + Agility.ToString() + " Agility";
        }
        if (Stamina > 0)
        {
            stats += "\n+" + Stamina.ToString() + " Stamina";
        }

        return string.Format("<color=" + color + "><size=16>{0}</size></color><size=14><i><color=lime>" + newLine + "{1}</color></i>{2}</size>", ItemName, Description, stats);
    }
}
