using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _spawnCount;

    [SerializeField] private Transform _highBorder;
    [SerializeField] private Transform _lowBorder;

    private Tilemap _grid;

    private void Start()
    {
        for (int i = 0; i < _spawnCount; i++) 
        {
            
            var randomPositionX = Random.Range(_lowBorder.position.x, _highBorder.position.x);
            var randomPositionY = Random.Range(_lowBorder.position.y, _highBorder.position.y);
            var enemy = Instantiate(_enemyPrefab, new Vector2(randomPositionX, randomPositionY), Quaternion.identity);
        }
    }
}
