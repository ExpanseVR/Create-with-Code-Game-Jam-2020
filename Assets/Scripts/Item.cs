using System;
using UnityEngine;

namespace CreateWithCodeGameJam2020.Scripts
{
    public abstract class Item : Interactable
    {
        public static event Action<ItemType> onGetItem;

        [SerializeField]
        private ItemType _itemType;

        public enum ItemType
        {
            Flute,
            Key
        }

        protected void CallOnGetItem (ItemType itemType)
        {
            onGetItem?.Invoke(itemType);
        }

        public ItemType GetItemType ()
        {
            return _itemType;
        }
    }
}