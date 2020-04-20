using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatUIView : MonoBehaviour
{

    [SerializeField] private Stat _stat;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;
    [SerializeField] private Gradient _fillingColors;
    [SerializeField] private Image _fillImage;

    private void OnEnable()
    {

        _stat.Changed += OnStatChanged;

        _text.text = _stat.Name;

        OnStatChanged(_stat.Value);

    }

    private void OnDisable()
    {

        _stat.Changed -= OnStatChanged;

    }

    private void OnStatChanged(float value)
    {

        _slider.value = value;
        _fillImage.color = _fillingColors.Evaluate(value);

    }

    private void Update()
    {
        _slider.value = _stat.Value;
        _fillImage.color = _fillingColors.Evaluate(_stat.Value);
    }

}
