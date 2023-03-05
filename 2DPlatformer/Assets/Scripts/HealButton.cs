using System.Collections;
using UnityEngine;

public class HealButton : MonoBehaviour
{
    [SerializeField] private Character _character;

    private int _heal = 10;
    private float _cooldown = 5f;
    private float _lastUsedTime = 0f;
    private bool _isButtonSelected = false;

    public void Heal()
    {
        if (!_isButtonSelected && Time.time - _lastUsedTime >= _cooldown)
        {
            _isButtonSelected = true;
            StartCoroutine(HealWithCooldown());
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
