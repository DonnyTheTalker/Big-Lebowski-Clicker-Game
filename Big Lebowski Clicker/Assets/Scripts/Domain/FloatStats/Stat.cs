using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Stats/Create Stat")]

public abstract class Stat : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private float _value;

    public event Action<float> Changed;

    public string Name => _name;
    public float Value => _value;

    public void SetValue(float value)
    {

        if (IsCorrect(value) == true)
            _value = value;
        else
            throw new ArgumentOutOfRangeException(nameof(value));
    }

    protected abstract bool IsCorrect(float value);

}
