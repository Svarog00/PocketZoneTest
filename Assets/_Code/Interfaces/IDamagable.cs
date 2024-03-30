using System;

namespace Assets._Code.Interfaces
{
    public interface IDamagable
    {
        EventHandler<OnHealthChangedEventArgs> OnHealthChanged { get; set; }

        void Damage(float damage);
    }
}