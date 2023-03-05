using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private Health _health;

    private Slider _slider;
    private Coroutine _coroutine;

    private float _fadeTime = 5f;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _health.HealthReduced += OnHealthReduced;
        _health.HealthIncresead += OnHealthIncreased;
    }

    private void OnDestroy()
    {
        _health.HealthReduced -= OnHealthReduced;
        _health.HealthIncresead -= OnHealthIncreased;
    }

    private void FadeSliderValueChange(float volumeTarget)
    {
        _coroutine = StartCoroutine(SliderValueChange(volumeTarget));
    }

    private IEnumerator SliderValueChange(float currentHealth)
    {
        float currentValue = _slider.value;
        float timer = 0f;
        float timeMultiply = 2f;
        float minValue = 0.01f;

        while (Mathf.Abs(currentValue - currentHealth) > minValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, _health.CurrentHealth, _fadeTime * Time.deltaTime * timeMultiply);
            _slider.value = currentValue;
            timer += Time.deltaTime;

            yield return null;
        }
    }
    public void OnHealthReduced(int currentHealth)
    {
        FadeSliderValueChange(currentHealth);
    }

    public void OnHealthIncreased(int currentHealth)
    {
        FadeSliderValueChange(currentHealth);
    }
}
