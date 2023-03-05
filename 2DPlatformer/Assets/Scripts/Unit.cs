using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public virtual void TakeDeadlyDamage()
    {
        Die();
    }

    public virtual void TakeDamage(int damage) { }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
