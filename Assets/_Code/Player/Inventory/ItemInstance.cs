using UnityEngine;

namespace Assets._Code.Player.Inventory
{
    public class ItemInstance : MonoBehaviour
    {
        [SerializeField] private int _bindedItemId;
        [SerializeField] private SpriteRenderer _spriteRenderer;


        public int ItemId => _bindedItemId;

        public void SetItem(ItemData item)
        {
            _bindedItemId = item.Id;
            _spriteRenderer.sprite = item.Image;
        }
    }
}