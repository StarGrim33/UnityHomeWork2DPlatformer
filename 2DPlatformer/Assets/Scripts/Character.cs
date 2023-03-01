using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{

    [SerializeField] private int _lives;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPosition;

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

    private void Shoot()
    {
        Bullet newBullet = Instantiate(_bullet, _shootPosition.position, _bullet.transform.rotation);
        newBullet.Parent = gameObject;
        newBullet.Direction = newBullet.transform.right * (_spriteRenderer.flipX? -1.0f : 1.0f);
    }

    public override void TakeDamage()
    {
        float impulse = 8.0f;

        _lives--;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.up * impulse, ForceMode2D.Impulse);

        Debug.Log(_lives);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.gameObject.GetComponent<Unit>();

        if(unit)
            TakeDamage();
    }
}
