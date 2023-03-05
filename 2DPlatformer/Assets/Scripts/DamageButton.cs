using System.Collections;
using UnityEngine;

public class DamageButton : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Coroutine _coroutine;

    private int _damage = 10;
    private float _cooldown = 2f;
    private float _lastUsedTime = 0f;
    private bool _isButtonSelected = false;

    public void ChangeHealth()
    {
        if (!_isButtonSelected && Time.time - _lastUsedTime >= _cooldown)
        {
            if(_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(DamageWithCooldown());
            _isButtonSelected = true;
        }
    }

    private IEnumerator DamageWithCooldown()
    {
        var waitForSeconds = new WaitForSeconds(_cooldown);

        _character.TakeDamage(_damage);
        _lastUsedTime -= Time.deltaTime;

        yield return waitForSeconds;
        _isButtonSelected = false;
    }
}
