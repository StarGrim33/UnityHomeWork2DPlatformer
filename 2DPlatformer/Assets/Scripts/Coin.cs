using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] private AudioClip _clip;

    public static event UnityAction Taken;

    private int _coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Character>(out Character character))
        {
            character.AddCoin(_coinValue);
            Taken?.Invoke ();

            if (_clip != null)
            {
                AudioSource.PlayClipAtPoint(_clip, transform.position); 
            }

            Destroy(gameObject);
        }
    }
}
