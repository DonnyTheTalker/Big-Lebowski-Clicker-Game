using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkinChange : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] private SpriteRenderer _currectVariant;
    [SerializeField] private Skin _mainSkin;
    [SerializeField] private BasicBool _skinActive;

    private Color lastColor = Color.white; 

    public GameObject Player, OnEnteredShowCase;

    Color redColor = Color.HSVToRGB(1.0f, 0.3820755f, 0.3820755f);

    public void OnPointerClick(PointerEventData eventData)
    {
        
        // changing sprite only if it's possible
        if (OnEnteredShowCase.GetComponent<SpriteRenderer>().color != redColor && OnEnteredShowCase.GetComponent<SpriteRenderer>().color != Color.black) {
            Player.GetComponent<SpriteRenderer>().sprite = _currectVariant.sprite;
            _mainSkin.SetSprite(_currectVariant.sprite);
        }
    
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        lastColor = _currectVariant.color;
        _skinActive.SetValue(true); 

        // highlight sprite if it's avaliable to use
        if (OnEnteredShowCase.GetComponent<SpriteRenderer>().color != Color.black) {
            _currectVariant.color = Color.gray;
            OnEnteredShowCase.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _skinActive.SetValue(false);
        if (OnEnteredShowCase.GetComponent<SpriteRenderer>().color != Color.black)
            _currectVariant.color = Color.white;
        OnEnteredShowCase.SetActive(false);
    }

    void Start()
    {
        OnEnteredShowCase.SetActive(false);
        Player.GetComponent<SpriteRenderer>().sprite = _mainSkin.SkinSprite;
    } 
}
