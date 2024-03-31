using Assets._Code.Characters;
using Assets._Code.Player.Inventory;
using System.IO;
using UnityEngine;

namespace Assets._Code.Infrastructure.SaveLoadSystem
{
    public class SaveManager : MonoBehaviour
    {
        [SerializeField] private GameObject _player;

        private HealthController _healthController;
        private PlayerInventory _playerInventory;

        private SaveLoadService _saveLoadService;

        private const string PlayerDataName = "PlayerData";

        private void Awake()
        {
            _saveLoadService = new SaveLoadService();

            _playerInventory = _player.GetComponent<PlayerInventory>();
            _healthController = _player.GetComponent<HealthController>();
        }

        public void SavePlayerData()
        {
            WorldData newData = new WorldData();
            newData.Items = _playerInventory.GetItemsId();
            newData.Health = _healthController.CurrentHealth;
            newData.x = _player.transform.position.x;
            newData.y = _player.transform.position.y;

            _saveLoadService.SaveData(PlayerDataName, newData);
        }

        public void LoadPlayerData()
        {
            WorldData data = _saveLoadService.LoadData(PlayerDataName);

            _player.transform.position = new Vector2(data.x, data.y);
            _healthController.SetHealth(data.Health);
            _playerInventory.LoadItems(data.Items);

            if (data.Health != 0)
            {
                _player.SetActive(true);
            }
        }

        public bool CheckProgressFile() =>
            File.Exists(Application.dataPath + "/Saves/" + PlayerDataName + ".sv");

    }
}