using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "BasicSkin")]

public class BasicSkin : Skin
{
    [SerializeField] private bool _isAchieved; // represents if skin is already bought
    [SerializeField] private bool _isReached; // represents if skin can be bought
    [SerializeField] private float _price;
    [SerializeField] private int _requiredLevel;

    public bool IsAchieved => _isAchieved;
    public bool IsReached => _isReached;
    public float Price => _price;
    public int RequiredLevel => _requiredLevel;

    public void SetPrice(float val)
    {
        _price = val;
    }
    public void Achieve(bool val = true)
    {
        _isAchieved = val;
    }

    public void Reach(bool val = true)
    {
        _isReached = val;
    }

}
