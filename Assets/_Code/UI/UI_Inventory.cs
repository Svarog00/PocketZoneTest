using Assets._Code.Player.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Code.UI
{
    public class UI_Inventory : MonoBehaviour
    {
        [SerializeField] private Transform _inventoryGridView;
        [SerializeField] private UI_ItemButton _itemGridInstancePrefab;

        [SerializeField] private PlayerInventory _inventorySource;

        [SerializeField] private GameObject _deleteButton;

        private bool _isActive = false;
        private int _selectedItemId = 0;

        private void Start()
        {
            gameObject.SetActive(_isActive);
            _deleteButton.SetActive(_isActive);
        }

        public void ToggleInvenotry()
        {
            UpdateView();

            _isActive = !_isActive;
            gameObject.SetActive(_isActive);
        }

        public void DeleteItem()
        {
            _inventorySource.RemoveItem(_selectedItemId);
            _deleteButton.SetActive(false);

            UpdateView();
        }

        private void UpdateView()
        {
            foreach (Transform button in _inventoryGridView.transform)
            {
                Destroy(button.gameObject);
            }

            foreach (var data in _inventorySource.Model.Items)
            {
                var itemButtonPrefab = Instantiate(_itemGridInstancePrefab, _inventoryGridView.transform);
                itemButtonPrefab.Initialize(data.Count, _inventorySource, data.Item.Image);
                var itemId = data.Item.Id;
                itemButtonPrefab.gameObject.GetComponent<Button>().onClick.AddListener(() => SelectItem(itemId));
            }
        }

        private void SelectItem(int id)
        {
            _selectedItemId = id;

            _deleteButton.SetActive(true);
        }
    }
}