using Assets._Code.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Player.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private ItemDatabase _itemDatabase;

        private InventoryModel _model;

        public InventoryModel Model => _model;

        private void Awake()
        {
            _model = new InventoryModel();
            _itemDatabase = Instantiate(_itemDatabase);
        }

        public void AddItem(int id)
        {
            var item = _itemDatabase.GetItem(id);
            _model.AddItem(item);
        }

        public void RemoveItem(int id)
        {
            var item = _itemDatabase.GetItem(id);
            _model.RemoveItem(item);
        }

        public void DecreaseItem(int id)
        {
            var item = _itemDatabase.GetItem(id);
            _model.DecreaseItemCount(item);
        }

        public IEnumerable<ItemInventoryData> GetItems()
        {
            return _model.Items;
        }

        public List<int> GetItemsId()
        {
            var newList = new List<int>();
            foreach (var item in _model.Items)
            {
                newList.Add(item.Item.Id);
            }

            return newList;
        }

        public bool TryGetItem(int id, out ItemInventoryData item)
        {
            if (GetItem(id) == null)
            {
                item = null;
                return false;
            }

            item = GetItem(id);
            return true;
        }

        public ItemInventoryData GetItem(int id)
        {
            return _model.Items.Find((item) => item.Item.Id == id);
        }

        public void LoadItems(List<int> items)
        {
            _model.ClearInventory();

            foreach (int id in items)
            {
                AddItem(id);
            }
        }
    }
}