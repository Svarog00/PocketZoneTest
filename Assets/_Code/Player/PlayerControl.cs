using Assets._Code.Characters;
using Assets._Code.Interfaces;
using Assets._Code.Player.Weapon;
using Assets._Code.UI;
using UnityEngine;

namespace Assets._Code.Player
{
    public class PlayerControl : MonoBehaviour
    {
        [SerializeField] private UI_Joystick _joystick;
        [SerializeField] private CharacterMovement _playerMovement;
        [SerializeField] private WeaponBase _weapon;

        private IInputService _inputService;

        private void Start()
        {
            _inputService = _joystick;
        }

        private void Update()
        {
            ProcessMovementInput();
        }

        public void Shoot()
        {
            _weapon.Shoot();
        }

        private void ProcessMovementInput()
        {
            _playerMovement.SetDirection(_inputService.InputDirection);
        }
    }
}