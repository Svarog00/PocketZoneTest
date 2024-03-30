using Assets._Code.Player.Inventory;
using UnityEngine;

namespace Assets._Code.Player
{
    public class ItemPicker : MonoBehaviour
    {
        [SerializeField] private PlayerInventory _inventory;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            ItemInstance itemInstance;
            if (collision.TryGetComponent(out itemInstance) == true)
            {
                _inventory.AddItem(itemInstance.ItemId);
                itemInstance.gameObject.SetActive(false);
            }
        }
    }
}