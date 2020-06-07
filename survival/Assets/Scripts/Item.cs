//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UnityEngine;

//namespace Assets.Scripts
//{
//    [Serializable]
//    public class Item
//    {
//        public enum ItemType
//        {
//            CreatureCatcher,
//            Book,
//            Soda,
//            Chocolate
//        }

//        public ItemType itemType;
//        public int amount;

//        public Sprite GetSprite()
//        {
//            switch(itemType)
//            {
//                default:
//                case ItemType.Book: return ItemAssets.Instance.bookSprite;
//                case ItemType.CreatureCatcher: return ItemAssets.Instance.creatureCatcherSprite;
//                case ItemType.Soda: return ItemAssets.Instance.sodaSprite;
//                case ItemType.Chocolate: return ItemAssets.Instance.chocolateSprite;
//            }
//        }

//        public bool IsStackable()
//        {
//            switch (itemType)
//            {
//                default:
//                case ItemType.Book:
//                case ItemType.CreatureCatcher:
//                    return false;
//                case ItemType.Soda:
//                case ItemType.Chocolate:
//                    return true;
//            }
//        }
//    }
//}
