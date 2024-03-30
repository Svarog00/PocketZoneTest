using Assets._Code.Interfaces;
using Assets._Code.Utilities;
using UnityEngine;

namespace Assets._Code.Player.Weapon
{
    public class BulletObject : MonoBehaviour, IPoolable<BulletObject>
    {
        [SerializeField] private float _speed;
        private float _damage;

        private Vector2 _direction;

        public ObjectPool<BulletObject> Pool { get; set; }

        private void Update()
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }

        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }

        public void SetDamage(float damage)
            => _damage = damage;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IDamagable target;
            if (collision.tag == "Enemy" && collision.TryGetComponent(out target))
            {
                target.Damage(_damage);
                Pool.Release(this);
            }
        }
    }
}