//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace Assets.Scripts
//{
//	public class Inventory
//	{
//		public event EventHandler OnItemListChanged;
//		private List<Item> itemList;

//		public Inventory()
//		{
//			itemList = new List<Item>();

//			AddItem(new Item { itemType = Item.ItemType.Book, amount = 1 });
//			AddItem(new Item { itemType = Item.ItemType.CreatureCatcher, amount = 1 });
//			AddItem(new Item { itemType = Item.ItemType.Chocolate, amount = 1 });
//			AddItem(new Item { itemType = Item.ItemType.Soda, amount = 1 });
//		}

//		public void AddItem(Item item)
//		{
//			if (item.IsStackable())
//			{
//				bool itemAlreadyInInventory = false;
//				foreach (Item inventoryItem in itemList)
//				{
//					if (inventoryItem.itemType == item.itemType)
//					{
//						inventoryItem.amount += item.amount;
//						itemAlreadyInInventory = true;
//					}
//				}
//				if (!itemAlreadyInInventory)
//				{
//					itemList.Add(item);
//				}
//			}
//			else
//			{
//				itemList.Add(item);
//			}
//			OnItemListChanged?.Invoke(this, EventArgs.Empty);
//		}

//		public void RemoveItem(Item item)
//		{
//			if (item.IsStackable())
//			{
//				Item itemInInventory = null;
//				foreach (Item inventoryItem in itemList)
//				{
//					if (inventoryItem.itemType == item.itemType)
//					{
//						inventoryItem.amount -= item.amount;
//						itemInInventory = inventoryItem;
//					}
//				}
//				if (itemInInventory != null && itemInInventory.amount <= 0)
//				{
//					itemList.Remove(item);
//				}
//			}
//			else
//			{
//				itemList.Remove(item);
//			}
//			OnItemListChanged?.Invoke(this, EventArgs.Empty);
//		}

//		public List<Item> GetItemList()
//		{
//			return itemList;
//		}
//	}
//}