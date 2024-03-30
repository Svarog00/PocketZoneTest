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

        public IEnumerable<ItemInventoryData> GetItems()
        {
            return _model.Items;
        }

        public ItemInventoryData GetItem(int id)
        {
            return _model.Items.Find((item) => item.Item.Id == id);
        }
    }
}