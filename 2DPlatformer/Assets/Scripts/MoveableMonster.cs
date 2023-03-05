using UnityEngine;
using System.Linq;

public class MoveableMonster : Monster
{
    [SerializeField] private float _speed;

    private Vector3 _direction;
    private int _damage = 15;

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
        if (collision.TryGetComponent<Character>(out Character character))
        {
            character.TakeDamage(_damage);
        }

        if(collision.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        float radius = 0.2f;
        float vectorRadius = 0.5f;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * vectorRadius + transform.right * _direction.x, radius);

        if(colliders.Length > 0 && colliders.All(x => !x.gameObject.GetComponent<Character>()))
        {
            _direction.x *= -1f;
        }

        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
    }
}
