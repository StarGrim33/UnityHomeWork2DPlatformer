using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int _obstacleDamage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Character>(out Character character))
        {
            character.TakeDamage(_obstacleDamage);
        }
    }
}
