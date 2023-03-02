using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer)), RequireComponent(typeof(Rigidbody2D))]
public class Character : Unit
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private int _coins;
    [SerializeField] private float _health;

    private float _maxHealth = 100;

    public event UnityAction<float> HealthChanged;

    public float Health 
    { 
        get { return _health; } 
        private set 
        { 
            _health = value; 

            if (_health <= 0) 
                _health = 0; 
        } 
    }
    
    public float MaxHealth { get { return _maxHealth; } }

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
        _rigidbody= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    public override void TakeDamage()
    {
        float impulse = 8.0f;
        int damage = 10;

        Health -= damage;

        HealthChanged?.Invoke(_health);

        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.up * impulse, ForceMode2D.Impulse);
    }

    public void AddCoin(int value)
    {
        _coins += value;
    }

    private void Shoot()
    {
        float flipMin = -1.0f;
        float flipMax = 1.0f;

        Bullet newBullet = Instantiate(_bullet, _shootPosition.position, _bullet.transform.rotation);
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (_spriteRenderer.flipX ? flipMin : flipMax);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Unit unit = collision.gameObject.GetComponent<Unit>();

    //    if (unit)
    //        TakeDamage();
    //}

    public void Heal()
    {
        int heal = 10;

        _health += heal;
    }
}
