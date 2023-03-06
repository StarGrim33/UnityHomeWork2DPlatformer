using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public Vector3 Direction { get { return _direction; } private set { _direction = value; } }

    private Transform _shooter;
    private Vector3 _direction;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed* Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Unit>(out Unit unit) && unit.transform != _shooter)
        {
            Destroy(gameObject);
        }
    }

    public void SetParentBullet(Transform parentTransform)
    {
        _shooter = parentTransform;
    }

    public void SetParentBulletDirection(Vector3 direction)
    {
        Direction = direction;
    }
}
