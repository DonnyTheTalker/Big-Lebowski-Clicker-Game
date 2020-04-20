using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopeClose : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private GameObject _shopPanel;

    public void OnPointerClick(PointerEventData eventData)
    {
        _shopPanel.SetActive(false);
    }
}
