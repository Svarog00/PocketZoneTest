using Assets._Code.Characters;
using Assets._Code.Player.Inventory;
using Assets._Code.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
    [SerializeField] private int _droppedItemId;
    [SerializeField] private ItemDatabase _items;
    [SerializeField] private ItemInstance _itemPrefab;

    [SerializeField] private HealthController _healthController;

    private void Awake()
    {
        _healthController.OnCharacterDeath += SpawnItem;
    }

    private void SpawnItem()
    {
        var instance = Instantiate(_itemPrefab, transform.position, Quaternion.identity);
        instance.SetItem(_items.GetItem(_droppedItemId));
    }
}
