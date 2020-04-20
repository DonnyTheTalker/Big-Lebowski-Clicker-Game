using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Skin")]

public class Skin : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _skinSprite; 

    public string Name => _name;
    public Sprite SkinSprite => _skinSprite;

    public void SetSprite(Sprite sprite)
    {
        _skinSprite = sprite;
    }
    

}
