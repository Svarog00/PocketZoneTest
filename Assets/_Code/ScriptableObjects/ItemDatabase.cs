using Assets._Code.Player.Inventory;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemDatabase", order = 1)]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField] private List<ItemData> _items = new List<ItemData>();

        public ItemData GetItem(int id)
        {
            return _items
                .Where((ItemData item) => item.Id == id)
                .First();
        }
    }
}