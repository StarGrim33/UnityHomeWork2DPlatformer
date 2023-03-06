using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _fadeTime = 50f;

    private Slider _slider;
    private Coroutine _coroutine;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _health.Reduced += OnHealthReduced;
        _health.Incresead += OnHealthIncreased;
    }

    private void OnDestroy()
    {
        _health.Reduced -= OnHealthReduced;
        _health.Incresead -= OnHealthIncreased;
    }

    public void OnHealthReduced(int currentHealth)
    {
        FadeSliderValueChange(currentHealth);
    }

    public void OnHealthIncreased(int currentHealth)
    {
        FadeSliderValueChange(currentHealth);
    }

    private void FadeSliderValueChange(float healthTarget)
    {
        if(_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(SliderValueChange(healthTarget));
    }

    private IEnumerator SliderValueChange(float target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _fadeTime * Time.deltaTime);
            yield return null;
        }
    }
}
