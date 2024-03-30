using Assets._Code.Player.Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Code.UI
{
    public class UI_ItemButton : MonoBehaviour
    {
        [SerializeField] private TMP_Text _countText;
        [SerializeField] private Image _image;

        private int _count;
        private PlayerInventory _inventory;

        public void Initialize(int count, PlayerInventory inventory, Sprite image)
        {
            _count = count;
            _inventory = inventory;
            _image.sprite = image;

            if (_count > 1)
            {
                _countText.text = _count.ToString();
            }
            else
            {
                _countText.gameObject.SetActive(false);
            }
        }
    }
}