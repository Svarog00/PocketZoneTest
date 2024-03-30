using Assets._Code.Player.Inventory;
using Assets._Code.Utilities;
using System;
using UnityEngine;

namespace Assets._Code.Player.Weapon
{
    public class WeaponBase : MonoBehaviour
    {
        public Action<int> OnWeaponShot;

        [Header("Weapon parameters")]
        [SerializeField] private BulletObject _bullet;
        [SerializeField] private Transform _shootOrigin;
        [SerializeField] private float _shootRadius;
        [SerializeField] private int _ammoId;
        [SerializeField] private float _damage;

        [Space]
        [Header("Dependency")]
        [SerializeField] private PlayerInventory _playerInventory;

        private int _ammoCount;
        private bool _haveTarget;
        private Vector3 _direction = Vector3.zero;
        private ObjectPool<BulletObject> _bulletPool;

        public int AmmoCount => _ammoCount;

        private void Awake()
        {
            _bulletPool = new ObjectPool<BulletObject>(() => Instantiate(_bullet, Vector3.zero, Quaternion.identity), 5);
        }

        public void Shoot()
        {
            var enemiesInRadius = Physics2D.OverlapCircleAll(transform.position, _shootRadius, LayerMask.GetMask("Characters"));
            _direction = GetDirectionToTargetEnemy(enemiesInRadius);
            
            if (CanShoot() == true)
            {
                SpawnBullet();

                _playerInventory.DecreaseItem(_ammoId);
            }
        }

        private void SpawnBullet()
        {
            var bullet = _bulletPool.GetFromPool();
            bullet.gameObject.transform.position = _shootOrigin.position;
            bullet.SetDirection(_direction);
            bullet.SetDamage(_damage);
        }

        private Vector3 GetDirectionToTargetEnemy(Collider2D[] enemies)
        {
            Vector3 direction = Vector3.zero;
            foreach (var enemy in enemies)
            {
                if (enemy.CompareTag("Enemy") == true)
                {
                    direction = enemy.transform.position - transform.position;
                    _haveTarget = true;
                    return direction.normalized;
                }
            }

            _haveTarget = false;
            return direction;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireSphere(transform.position, _shootRadius);
        }

        private bool CanShoot()
        {
            ItemInventoryData itemData;
            if (_playerInventory.TryGetItem(_ammoId, out itemData) == false)
            {
                return false;
            }

            _ammoCount = itemData.Count;
            return _ammoCount > 0 && _haveTarget == true;
        }
    }
}