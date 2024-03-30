using Assets._Code.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Enemies
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private float _attackDistance;
        [SerializeField] private float _damage;

        [SerializeField] private float _attackDelay;

        [SerializeField] private Transform _attackPoint;

        [SerializeField] private LayerMask _enemyLayers;

        private float _currentDelay;

        private const string PlayerTag = "Player";

        public float AttackDistance => _attackDistance;

        void Update()
        {
            Cooldown();
        }

        public void Attack()
        {
            if (_currentDelay <= 0)
            {
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackDistance, _enemyLayers);
                //damage them
                IDamagable tmpDamagable;
                foreach (Collider2D enemy in hitEnemies)
                {
                    if (enemy.gameObject.tag.Contains(PlayerTag) && enemy.TryGetComponent(out tmpDamagable))
                    {
                        tmpDamagable.Damage(_damage);
                    }
                }

                _currentDelay = _attackDelay;

            }
        }

        private void Cooldown()
        {
            if (_currentDelay > 0f)
            {
                _currentDelay -= Time.deltaTime;
            }
        }

        void OnDrawGizmosSelected()
        {
            if (_attackPoint == null)
            {
                return;
            }
            Gizmos.DrawWireSphere(_attackPoint.position, _attackDistance);
        }
    }
}