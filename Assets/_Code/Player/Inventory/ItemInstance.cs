using UnityEngine;

namespace Assets._Code.Player.Inventory
{
    public class ItemInstance : MonoBehaviour
    {
        [SerializeField] private int _bindedItemId;

        public int ItemId => _bindedItemId;
    }
}