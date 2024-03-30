using System;
using System.Collections.Generic;

namespace Assets._Code.Player.Inventory
{
    public class ItemInventoryData
    {
        public ItemData Item;
        public int Count;
    }

    public class InventoryModel
    {
        public Action OnItemAdded;
        public Action<int> OnItemDeleted;

        private List<ItemInventoryData> _items;

        public List<ItemInventoryData> Items => _items;

        public InventoryModel() 
        {
            _items = new List<ItemInventoryData>();
        }

        public void AddItem(ItemData item)
        {
            foreach (var itemData in _items)
            {
                if (itemData.Item.Equals(item))
                {
                    itemData.Count++;
                    OnItemAdded?.Invoke();
                    return;
                }
            }

            _items.Add(new ItemInventoryData { Item = item, Count = 1 });

            OnItemAdded?.Invoke();
        }

        public void RemoveItem(ItemData item) 
        {
            foreach (var itemData in _items)
            {
                if (itemData.Item.Equals(item))
                {
                    _items.Remove(itemData);
                    OnItemDeleted?.Invoke(item.Id);
                    return;
                }
            }
        }

        public void DecreaseItemCount(ItemData item)
        {
            foreach (var itemData in _items)
            {
                if (itemData.Item.Equals(item))
                {
                    itemData.Count--;
                    if (itemData.Count == 0)
                    {
                        _items.Remove(itemData);
                    }
                    return;
                }
            }
        }
        
        public void ClearInventory()
        {
            if (_items.Count == 0)
                return;

            _items.Clear();
        }
    }
}