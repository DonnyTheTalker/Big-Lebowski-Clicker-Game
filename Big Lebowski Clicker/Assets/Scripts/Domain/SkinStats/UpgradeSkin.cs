using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "UpgradeSkin")]
public class UpgradeSkin : BasicSkin
{

    // profits that upgrade provides us

    [SerializeField] private float _clickProfit;
    [SerializeField] private float _autoClickProfit;
    [SerializeField] private float _bowlingProfit;
    [SerializeField] private float _easeProfit;
    [SerializeField] private int _nIterations; // is needed to return stats to default value

    public float ClickProfit => _clickProfit;
    public float AutoClickProfit => _autoClickProfit;
    public float BowlingProfit => _bowlingProfit;
    public float EaseProfit => _easeProfit;

    public int Iterations => _nIterations;

    public void SetIterations(int value)
    {
        _nIterations = value;
    }

    public void SetClickProfit(float value)
    {
        _clickProfit = value;
    }

    public void SetAutoClickProfit(float value)
    {
        _autoClickProfit = value;
    }

    public void SetEaseProfit(float value)
    {
        _easeProfit = value;
    }

    public void SetBowlingProfit(float value)
    {
        _bowlingProfit = value;
    }
}
