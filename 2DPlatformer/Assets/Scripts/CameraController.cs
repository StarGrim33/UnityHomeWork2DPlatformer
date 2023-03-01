using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Character))]
public class CameraController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _target;

    private void Awake()
    {
        _target = FindObjectOfType<Character>().transform;
    }

    private void Update()
    {
        Vector3 position = _target.position;
        position.z = -10.0f;
        transform.position = Vector3.Lerp(transform.position, position, _speed * Time.deltaTime);
    }
}
