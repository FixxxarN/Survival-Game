//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TMPro;
//using UnityEngine;
//using UnityEngine.UI;

//namespace Assets.Scripts
//{
//    public class UI_Inventory : MonoBehaviour
//    {
//        private Inventory inventory;
//        private Transform itemSlotContainer;
//        private Transform itemSlotTemplate;
//        private PlayerController player;

//        private void Awake()
//        {
//            itemSlotContainer = transform.Find("ItemSlotContainer");
//            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");
//        }

//        public void SetPlayer(PlayerController player)
//        {
//            this.player = player;
//        }

//        public void SetInventory(Inventory inventory)
//        {
//            this.inventory = inventory;
//            inventory.OnItemListChanged += Inventory_OnItemListChanged;
//            //RefreshInventoryItems();
//        }

//        private void Inventory_OnItemListChanged(object sender, EventArgs e)
//        {
//            //RefreshInventoryItems();
//        }

//        private void RefreshInventoryItems()
//        {
//            foreach(Transform child in itemSlotContainer)
//            {
//                if (child == itemSlotTemplate) continue;
//                Destroy(child.gameObject);
//            }
//            int x = 0;
//            int y = 0;
//            float itemSlotCellSize = 36f;
//            foreach(Item item in inventory.GetItemList())
//            {
//                RectTransform itemSlotRecttransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
//                itemSlotRecttransform.gameObject.SetActive(true);
//                itemSlotRecttransform.anchoredPosition = new Vector2(x * itemSlotCellSize, -y * itemSlotCellSize);
//                Image image = itemSlotRecttransform.Find("Image").GetComponent<Image>();
//                image.sprite = item.GetSprite();
//                TextMeshProUGUI uiText = itemSlotRecttransform.Find("Amount").GetComponent<TextMeshProUGUI>();
//                if (item.amount > 1)
//                    uiText.SetText(item.amount.ToString());
//                else
//                    uiText.SetText("");
//                image.SetNativeSize();
//                x++;
//                if(x > 5)
//                {
//                    x = 0;
//                    y++;
//                }
//            }
//        }
//    }
//}
