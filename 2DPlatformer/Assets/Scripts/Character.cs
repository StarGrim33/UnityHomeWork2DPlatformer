using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Unit
{

    [SerializeField] private int _lives;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPosition;
    [SerializeField] private int _coins;

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

        _lives--;
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.up * impulse, ForceMode2D.Impulse);

        Debug.Log(_lives);
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Unit unit = collider.gameObject.GetComponent<Unit>();

        if(unit)
            TakeDamage();
    }
}
