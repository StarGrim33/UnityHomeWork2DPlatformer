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

    private Rigidbody2D _rigidbody;
    private SpriteRenderer _spriteRenderer;
    private Health _health;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    private void Shoot()
    {
        float flipMin = -1.0f;
        float flipMax = 1.0f;

        Bullet newBullet = Instantiate(_bullet, _shootPosition.position, _bullet.transform.rotation);
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (_spriteRenderer.flipX ? flipMin : flipMax);
    }

    public override void TakeDamage(int damage)
    {
        float impulse = 8.0f;

        _health.TakeDamage(damage);
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.up * impulse, ForceMode2D.Impulse);
    }

    public void AddCoin(int value)
    {
        _coins += value;
    }

    public void Heal(int heal)
    {
        _health.Heal(heal);
    }
}
