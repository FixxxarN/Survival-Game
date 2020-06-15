using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hotbar : Inventory
{
    private RectTransform hotbarRect;

    private float hotbarWidth, hotbarHeight;


    void Start()
    {
        CreateLayout();
    }

    void CreateLayout()
    {
        
        hotbarWidth = 10 * (SlotSize + slotPaddingLeft) + slotPaddingLeft;
        hotbarHeight = 1 * (SlotSize + slotPaddingTop) + slotPaddingTop;

        hotbarRect= GetComponent<RectTransform>();

        hotbarRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hotbarWidth);
        hotbarRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, hotbarHeight);

        for (int x = 0; x < 10; x++)
        {
            GameObject newSlot = (GameObject)Instantiate(slotPrefab);

            RectTransform slotRect = newSlot.GetComponent<RectTransform>();

            newSlot.name = "Slot";
            newSlot.transform.SetParent(this.transform);

            slotRect.localPosition = new Vector3(slotPaddingLeft * (x + 1) + (SlotSize * x), -slotPaddingTop);

            slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SlotSize);
            slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SlotSize);

            allSlots.Add(newSlot);
        }

        EmptySlots = allSlots.Count;
    }
}
