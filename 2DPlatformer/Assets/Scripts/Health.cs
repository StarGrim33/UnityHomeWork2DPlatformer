using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public event UnityAction<int> HealthReduced;
    public event UnityAction<int> HealthIncresead;

    public int CurrentHealth
    {
        get { return _health; }
        private set
        {
            _health = value;

            if (_health <= 0)
                _health = 0;
            else if (_health > _maxHealth)
                _health = _maxHealth;
        }
    }

    public int MaxHealth { get { return _maxHealth; } }

    public void Heal(int heal)
    {
        CurrentHealth += heal;
        HealthIncresead?.Invoke(CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        HealthReduced?.Invoke(CurrentHealth);
    }
}
