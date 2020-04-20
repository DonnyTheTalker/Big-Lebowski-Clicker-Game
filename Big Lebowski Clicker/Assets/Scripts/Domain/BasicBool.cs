using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "BasicBool")]

public class BasicBool : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private bool _value;

    public string Name => _name;
    public bool Value => _value;

    public void SetValue(bool val)
    {
        _value = val;
    }


}
