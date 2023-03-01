using UnityEngine;
using System.Linq;

public class MoveableMonster : Monster
{
    [SerializeField] private float _speed;

    private Vector3 _direction;

    private void Awake()
    {
        _direction = transform.right;
    }

    private void Update()
    {
        Move();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            TakeDamage();
        }
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.5f + transform.right * _direction.x, 0.2f);

        if(colliders.Length > 0 && colliders.All(x => !x.gameObject.GetComponent<Character>()))
        {
            _direction.x *= -1f;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
    }
}
