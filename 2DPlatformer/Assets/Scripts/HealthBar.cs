using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;

    private Slider _slider;
    private float _fillSpeed = 0.3f;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _character.HealthChanged += OnSliderValueChanged;
    }

    private void OnDestroy()
    {
        _character.HealthChanged -= OnSliderValueChanged;
    }

    public void OnSliderValueChanged(float currentHealth)
    {
        _slider.DOKill();
        _slider.DOValue(currentHealth, _fillSpeed, false);
    }
}
