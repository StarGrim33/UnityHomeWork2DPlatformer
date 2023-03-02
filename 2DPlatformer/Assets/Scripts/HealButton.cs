using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Character _character;

    public void Heal()
    {
        if (_character != null)
        {
            _character.Heal();
        }
    }
}
