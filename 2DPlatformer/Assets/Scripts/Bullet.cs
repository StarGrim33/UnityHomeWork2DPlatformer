using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public GameObject Parent { get { return _parent; } private set { _parent = value; } }

    public Vector3 Direction { get { return _direction; } private set { _direction = value; } }

    private GameObject _parent;
    private Vector3 _direction;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed* Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Unit>(out Unit unit) && unit.gameObject != Parent)
        {
            Destroy(gameObject);
        }
    }

    public void SetParentBullet(GameObject parent)
    {
        Parent = parent;
    }

    public void SetParentBulletDirection(Vector3 direction)
    {
        Direction = direction;
    }
}
