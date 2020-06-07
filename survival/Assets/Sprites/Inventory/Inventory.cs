using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private RectTransform inventoryRect;

    private float inventoryWidth, inventoryHeight;

    public int Slots;
    public int Rows;

    public float slotPaddingLeft, slotPaddingTop;

    public float SlotSize;

    public GameObject slotPrefab;

    private static Slot from, to;

    private List<GameObject> allSlots;

    public GameObject iconPrefab;

    private static GameObject hoverObject;

    private static int emptySlots;

    public Canvas Canvas;

    public EventSystem EventSystem;

    private float hoverYOffset;


    public static int EmptySlots { get => emptySlots; set => emptySlots = value; }

    void Start()
    {
        CreateLayout();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(!EventSystem.IsPointerOverGameObject(-1) && from != null)
            {
                from.GetComponent<Image>().color = Color.white;
                from.ClearSlot();
                Destroy(GameObject.Find("Hover"));
                to = null;
                from = null;
                hoverObject = null;
            }
        }
        if(hoverObject != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.GetComponent<RectTransform>(), Input.mousePosition, Canvas.worldCamera, out position);

            hoverObject.transform.position = Input.mousePosition;

        }
    }

    void CreateLayout()
    {
        allSlots = new List<GameObject>();

        hoverYOffset = 1000;

        EmptySlots = Slots;

        inventoryWidth = (Slots / Rows) * (SlotSize + slotPaddingLeft) + slotPaddingLeft;
        inventoryHeight = Rows * (SlotSize + slotPaddingTop) + slotPaddingTop;

        inventoryRect = GetComponent<RectTransform>();

        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, inventoryWidth);
        inventoryRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, inventoryHeight);

        int columns = Slots / Rows;

        for(int y = 0; y < Rows; y++)
        {
            for(int x = 0; x < columns; x++)
            {
                GameObject newSlot = (GameObject)Instantiate(slotPrefab);

                RectTransform slotRect = newSlot.GetComponent<RectTransform>();

                newSlot.name = "Slot";
                newSlot.transform.SetParent(this.transform.parent);

                slotRect.localPosition = inventoryRect.localPosition + new Vector3(slotPaddingLeft * (x + 1) + (SlotSize * x), -slotPaddingTop * (y + 1) - (SlotSize * y));

                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, SlotSize);
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, SlotSize);

                allSlots.Add(newSlot);
            }
        }
    }

    public bool AddItem(Item item)
    {
        if(item.MaxSize == 1)
        {
            PlaceEmpty(item);
            return true;
        }
        else
        {
            foreach(GameObject slot in allSlots)
            {
                Slot temp = slot.GetComponent<Slot>();
                
                if(!temp.IsEmpty)
                {
                    if(temp.CurrenItem.Type == item.Type && temp.IsAvailable)
                    {
                        temp.AddItem(item);
                        return true;
                    }
                }
            }
            if(EmptySlots > 0)
            {
                PlaceEmpty(item);
            }
        }
        return false;
    }

    bool PlaceEmpty(Item item)
    {
        if(EmptySlots > 0)
        {
            foreach(GameObject slot in allSlots)
            {
                Slot temp = slot.GetComponent<Slot>();

                if(temp.IsEmpty)
                {
                    temp.AddItem(item);
                    EmptySlots--;
                    return true;
                }
            }
        }
        return false;
    }

    public void MoveItem(GameObject clicked)
    {
        if(from == null)
        {
            if(!clicked.GetComponent<Slot>().IsEmpty)
            {
                from = clicked.GetComponent<Slot>();
                from.GetComponent<Image>().color = Color.grey;

                hoverObject = (GameObject)Instantiate(iconPrefab);
                hoverObject.GetComponent<Image>().sprite = clicked.GetComponent<Image>().sprite;
                hoverObject.name = "Hover";

                RectTransform hoverTransform = hoverObject.GetComponent<RectTransform>();
                RectTransform clickedTransform = clicked.GetComponent<RectTransform>();

                hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, clickedTransform.sizeDelta.x);
                hoverTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, clickedTransform.sizeDelta.y);

                hoverObject.transform.SetParent(GameObject.Find("Canvas").transform, true);
                hoverObject.transform.localScale = from.gameObject.transform.localScale;
            }
        }
        else if(to == null)
        {
            to = clicked.GetComponent<Slot>();
            Destroy(GameObject.Find("Hover"));
        }
        if(to != null && from != null)
        {
            Stack<Item> tempTo = new Stack<Item>(to.Items);
            to.AddItems(from.Items);

            if (tempTo.Count == 0)
            {

                from.ClearSlot();
            }
            else
            {
                from.AddItems(tempTo);
            }

            from.GetComponent<Image>().color = Color.white;
            to = null;
            from = null;
            hoverObject = null;
        }
    }
}
