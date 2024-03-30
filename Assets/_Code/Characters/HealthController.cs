using Assets._Code.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Code.Characters
{
    public class HealthController : MonoBehaviour, IDamagable
    {
        public EventHandler<OnHealthChangedEventArgs> OnHealthChanged { get; set; }

        [SerializeField] private float _maxHealth;

        private float _currentHealth;

        public float CurrentHealth => _currentHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;

            OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHealth / _maxHealth });
        }

        public void Damage(float damage)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHealth / _maxHealth });
            if (_currentHealth <= 0)
            {
                ProcessDeath();
            }
        }

        public void SetHealth(float health)
        {
            _currentHealth = Math.Clamp(_currentHealth, health, _maxHealth);

            OnHealthChanged?.Invoke(this, new OnHealthChangedEventArgs { CurrentHealth = _currentHealth / _maxHealth });
        }

        private void ProcessDeath()
        {
            gameObject.SetActive(false);
        }
    }
}