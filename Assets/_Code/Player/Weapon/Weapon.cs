using Assets._Code.Player.Inventory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Player
{
    public class Weapon : MonoBehaviour
    {
        public Action<int> OnWeaponShot;

        [Header("Weapon parameters")]
        [SerializeField] private BulletObject _bullet;
        [SerializeField] private Transform _shootOrigin;
        [SerializeField] private float _shootRadius;
        [SerializeField] private int _ammoId;

        [Space]
        [Header("Dependency")]
        [SerializeField] private PlayerInventory _playerInventory;

        private int _ammoCount;
        private Vector3 _direction = Vector3.zero;

        public int AmmoCount => _ammoCount;

        public void Shoot()
        {
            if (CanShoot() == true)
            {
                var enemiesInRadius = Physics2D.OverlapCircleAll(transform.position, _shootRadius, LayerMask.GetMask("Characters"));
                var direction = GetDirectionToTargetEnemy(enemiesInRadius);

                SpawnBullet();
            }
        }

        private void SpawnBullet()
        {
            var bullet = Instantiate(_bullet, _shootOrigin.position, Quaternion.identity);
        }

        private Vector3 GetDirectionToTargetEnemy(Collider2D[] enemies )
        {
            Vector3 direction = Vector3.zero;
            foreach (var enemy in enemies)
            {
                if (enemy.CompareTag("Enemy") == true)
                {
                    direction = enemy.transform.position - transform.position;
                    return direction.normalized;
                }
            }

            return direction;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _shootRadius);
        }

        private bool CanShoot() => _ammoCount > 0;
    }
}