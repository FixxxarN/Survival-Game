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

    public static Slot from, to;

    protected List<GameObject> allSlots;

    public GameObject iconPrefab;

    private static GameObject hoverObject;

    private static int emptySlots;

    public Canvas Canvas;

    public EventSystem EventSystem;

    private static CanvasGroup canvasGroup;

    public static CanvasGroup CanvasGroup { get => canvasGroup; }

    private bool fadingIn, fadingOut;

    public float FadeTime;

    private static GameObject tooltip;

    public GameObject ToolTip;

    private static Text sizeText;

    public Text SizeTextObject;

    private static Text visualText;

    public Text VisualTextObject;

    public static int EmptySlots { get => emptySlots; set => emptySlots = value; }

    void Awake()
    {
        CreateLayout();
    }

    void Start()
    {
        tooltip = ToolTip;
        sizeText = SizeTextObject;
        visualText = VisualTextObject;
        canvasGroup = transform.parent.GetComponent<CanvasGroup>();
    }

    
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(!EventSystem.IsPointerOverGameObject(-1) && from != null)
            {
                from.GetComponent<Image>().color = Color.white;
                foreach(Item item in from.Items)
                {
                    //Fixa med playerLocalScale for o veta om han är vänd åt höger eller vänster i både AddForce och instansen
                    Item tempItem = Instantiate(item, GameObject.Find("Player").transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
                    tempItem.GetComponent<Rigidbody2D>().AddForce(transform.right * 1f, ForceMode2D.Impulse);
                }
                from.ClearSlot();
                Destroy(GameObject.Find("Hover"));
                to = null;
                from = null;
                emptySlots++;
            }
        }
        if(hoverObject != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(Canvas.GetComponent<RectTransform>(), Input.mousePosition, Canvas.worldCamera, out position);

            hoverObject.transform.position = Input.mousePosition;

        }
        if(Input.GetKeyDown(KeyCode.B))
        {
            if(canvasGroup.alpha > 0)
            {
                StartCoroutine("FadeOut");
                PutItemBack();
            }
            else
            {
                StartCoroutine("FadeIn");
            }
        }
        //if(Input.GetMouseButton(0))
        //{
        //    if(EventSystem.IsPointerOverGameObject(-1))
        //    {
        //        MoveInventory();
        //    }
        //}
    }

    //private void MoveInventory()
    //{
    //    transform.position = new Vector3(Input.mousePosition.x - (inventoryRect.sizeDelta.x / 2 * Canvas.scaleFactor), Input.mousePosition.y + (inventoryRect.sizeDelta.y / 2 * Canvas.scaleFactor));
    //}

    public void ShowTooltip(GameObject slot)
    {
        Slot tempSlot = slot.GetComponent<Slot>();

        if(!tempSlot.IsEmpty && hoverObject == null)
        {
            visualText.text = tempSlot.CurrenItem.GetTooltip();
            sizeText.text = visualText.text;

            tooltip.SetActive(true);

            float xPos = slot.transform.position.x + slotPaddingLeft;
            float yPos = slot.transform.position.y - slot.GetComponent<RectTransform>().sizeDelta.y - slotPaddingTop;

            tooltip.transform.position = new Vector2(xPos, yPos);
        }

    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    void CreateLayout()
    {
        allSlots = new List<GameObject>();

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
                newSlot.transform.SetParent(this.transform);

                slotRect.localPosition = new Vector3(slotPaddingLeft * (x + 1) + (SlotSize * x), -slotPaddingTop * (y + 1) - (SlotSize * y));

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
        if(from == null && canvasGroup.alpha == 1)
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
            Destroy(GameObject.Find("Hover"));
        }
    }

    private void PutItemBack()
    {
        if(from != null)
        {
            Destroy(GameObject.Find("Hover"));
            from.GetComponent<Image>().color = Color.white;
            from = null;
        }
    }

    private IEnumerator FadeOut()
    {
        if(!fadingOut)
        {
            fadingOut = true;
            fadingIn = false;
            StopCoroutine("FadeIn");

            float startAlpha = canvasGroup.alpha;
            float rate = 1.0f / FadeTime;
            float progress = 0.0f;

            while(progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }

            canvasGroup.alpha = 0;
            fadingOut = false;
        }
    }

    private IEnumerator FadeIn()
    {
        if (!fadingIn)
        {
            fadingOut = false;
            fadingIn = true;
            StopCoroutine("FadeOut");

            float startAlpha = canvasGroup.alpha;
            float rate = 1.0f / FadeTime;
            float progress = 0.0f;

            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, 1, progress);

                progress += rate * Time.deltaTime;

                yield return null;
            }

            canvasGroup.alpha = 1;
            fadingIn = false;
        }
    }
}
