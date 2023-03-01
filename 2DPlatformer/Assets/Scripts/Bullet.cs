using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    public GameObject Parent { set { _parent = value; } }
    private GameObject _parent;

    public Vector3 Direction { set { _direction = value; } }
    private Vector3 _direction;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed* Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Unit>(out Unit unit) && unit.gameObject != _parent)
        {
            Destroy(gameObject);
        }
    }
}
