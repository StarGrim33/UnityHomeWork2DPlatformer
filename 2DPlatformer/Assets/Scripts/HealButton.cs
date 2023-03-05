using System.Collections;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Coroutine _coroutine;

    private int _heal = 10;
    private float _cooldown = 2f;
    private float _lastUsedTime = 0f;
    private bool _isButtonSelected = false;

    public void Heal()
    {
        if (!_isButtonSelected && Time.time - _lastUsedTime >= _cooldown)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _coroutine = StartCoroutine(HealWithCooldown());
            _isButtonSelected = true;
        }        
    }

    private IEnumerator HealWithCooldown()
    {
        var waitForSeconds = new WaitForSeconds(_cooldown);

        _character.Heal(_heal);
        _lastUsedTime -= Time.deltaTime;

        yield return waitForSeconds;
        _isButtonSelected = false;
    }
}
