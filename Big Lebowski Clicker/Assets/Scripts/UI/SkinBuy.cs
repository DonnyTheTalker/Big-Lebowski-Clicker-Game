using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinBuy : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler
{

    [SerializeField] private BasicSkin _currectSkin, _nextSkin;
    [SerializeField] private WholeStat _userMoney;
    [SerializeField] private Image _skin;
    [SerializeField] private Text _text;
    [SerializeField] private Button _moneyButton;
    [SerializeField] private Button _localMoney;
    [SerializeField] private Text _price;
    [SerializeField] private BasicSkin _jesus; // easter-egg skin
    [SerializeField] private WholeStat _playerLevel;
    [SerializeField] private Button _requiredLevel;
    [SerializeField] private string _unknownTitle;

    Color redColor = Color.HSVToRGB(1.0f, 0.3820755f, 0.3820755f);
    Color greenColor = Color.HSVToRGB(1.0f, 0.3820755f, 0.3820755f);

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_skin.color == Color.gray) {
            _userMoney.SetValue(_userMoney.Value - _currectSkin.Price);
            _currectSkin.Achieve();
            _nextSkin.Reach();
            _moneyButton.GetComponentInChildren<Text>().text = ((int)_userMoney.Value).ToString();
            _localMoney.GetComponentInChildren<Text>().text = ((int)_userMoney.Value).ToString();
            _price.text = "Owned";

            if (_nextSkin.Name == "Jesus") 
                _jesus.Achieve();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (!_currectSkin.IsReached)
            _skin.color = Color.black;
        else if (_currectSkin.IsAchieved)
            _skin.color = greenColor;
        else if (_userMoney.Value < _currectSkin.Price || _playerLevel.Value < _currectSkin.RequiredLevel)
            _skin.color = redColor;
        else
            _skin.color = Color.grey;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_skin.color != Color.black) {
            _skin.color = Color.white;
        }
    }

    void Start()
    {
        _localMoney.GetComponentInChildren<Text>().text = ((int)_userMoney.Value).ToString();
        _skin.sprite = _currectSkin.SkinSprite;
        _requiredLevel.GetComponentInChildren<Text>().text = ((int)_currectSkin.RequiredLevel).ToString();

        if (_currectSkin.IsAchieved) {
            _skin.color = Color.white;
            _text.text = _currectSkin.Name;
            _price.text = "Owned";
        } else if (_currectSkin.IsReached) {
            _skin.color = Color.white;
            _text.text = _currectSkin.Name;
            _price.text = ((int)_currectSkin.Price).ToString();
        } else {
            _skin.color = Color.black;
            _text.text = _unknownTitle;
            _price.text = "Priceless";
        }

    }

    void Update()
    {
        _localMoney.GetComponentInChildren<Text>().text = ((int)_userMoney.Value).ToString();
        if (_currectSkin.IsReached && _skin.color == Color.black) {

            _skin.color = Color.white;
            _text.text = _currectSkin.Name;
            _price.text = ((int)_currectSkin.Price).ToString();
        }

    }
}
