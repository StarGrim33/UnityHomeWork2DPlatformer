using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinValue;
    [SerializeField] private AudioClip _clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Character>(out Character character))
        {
            Debug.Log("Монетка + 1");
            character.AddCoin(_coinValue);

            if (_clip != null)
            {
                AudioSource.PlayClipAtPoint(_clip, transform.position); 
            }

            Destroy(gameObject);
        }
    }
}
