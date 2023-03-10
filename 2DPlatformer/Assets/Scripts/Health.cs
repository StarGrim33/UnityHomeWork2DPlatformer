using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _maxHealth;

    public event UnityAction<int> Reduced;
    public event UnityAction<int> Incresead;

    public int CurrentHealth
    {
        get { return _health; }
        private set
        {
            _health = Mathf.Clamp(value, 0, _maxHealth);
        }
    }

    public int MaxHealth => _maxHealth;

    public void Heal(int heal)
    {
        CurrentHealth += heal;
        Debug.Log(CurrentHealth);
        Incresead?.Invoke(CurrentHealth);
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log(CurrentHealth);
        Reduced?.Invoke(CurrentHealth);
    }
}
