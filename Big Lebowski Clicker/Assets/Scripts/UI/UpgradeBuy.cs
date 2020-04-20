using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeBuy : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler,
    IPointerExitHandler
{

    // All required stats
    [SerializeField] private WholeStat _userMoney;
    [SerializeField] private WholeStat _bowlingLevel;
    [SerializeField] private WholeStat _easeLevel;
    [SerializeField] private MoneyStat _moneyPerSecond;
    [SerializeField] private MoneyStat _moneyPerClick;
    [SerializeField] private NormalizedStat _bowlingProgress;
    [SerializeField] private NormalizedStat _easeProgress;

    // All required UI
    [SerializeField] private Text _bowlingLevelText;
    [SerializeField] private Text _easeLevelText;
    [SerializeField] private Button _bowlingLevelButton;
    [SerializeField] private Button _easeLevelButton; 
    [SerializeField] private Button _moneyPerSecondButton;
    [SerializeField] private Button _moneyPerClickButton;

    [SerializeField] private Text _perClickProfit;
    [SerializeField] private Text _perSecondProfit;
    [SerializeField] private Text _upgradeName;
    [SerializeField] private Text _upgradePrice;
    [SerializeField] private UpgradeSkin _upgradeSkin;
    [SerializeField] private UpgradeSkin _nextSkin;
    [SerializeField] private Image _upgradeImage;

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (_upgradeImage.color == Color.grey) {

            _nextSkin.Achieve();

            _upgradeSkin.SetIterations(_upgradeSkin.Iterations + 1);

            _userMoney.SetValue(_userMoney.Value - _upgradeSkin.Price); 
            _moneyPerSecond.SetValue(_moneyPerSecond.Value + _upgradeSkin.AutoClickProfit);
            _moneyPerClick.SetValue(_moneyPerClick.Value + _upgradeSkin.ClickProfit);
            _bowlingProgress.SetValue(Math.Min(1.0f, _bowlingProgress.Value + _upgradeSkin.BowlingProfit));
            _easeProgress.SetValue(Math.Min(1.0f, _easeProgress.Value + _upgradeSkin.EaseProfit));

            _upgradeSkin.SetPrice(_upgradeSkin.Price * 1.5f);
            _upgradeSkin.SetAutoClickProfit(_upgradeSkin.AutoClickProfit * 1.1f);
            _upgradeSkin.SetClickProfit(_upgradeSkin.ClickProfit * 1.2f);
            _upgradeSkin.SetBowlingProfit(_upgradeSkin.BowlingProfit * 0.9f);
            _upgradeSkin.SetEaseProfit(_upgradeSkin.EaseProfit * 0.9f);

            _perClickProfit.text = String.Format("{0:f3}", _upgradeSkin.ClickProfit);
            _perSecondProfit.text = String.Format("{0:f3}", _upgradeSkin.AutoClickProfit);
            _upgradePrice.text = String.Format("{0:f3}", _upgradeSkin.Price);

            _moneyPerClickButton.GetComponentInChildren<Text>().text = String.Format("{0:f3}", _moneyPerClick.Value);
            _moneyPerSecondButton.GetComponentInChildren<Text>().text = String.Format("{0:f3}", _moneyPerSecond.Value);

            if (_bowlingProgress.Value == 1 && _bowlingLevel.Value < 9) {
                _bowlingLevel.SetValue(_bowlingLevel.Value + 1);
                _bowlingProgress.SetValue(0.0f);
                _bowlingLevelText.text = ((int)(_bowlingLevel.Value)).ToString();
                _bowlingLevelButton.GetComponentInChildren<Text>().text = ((int)(_bowlingLevel.Value)).ToString();
            }

            if (_easeProgress.Value == 1 && _easeLevel.Value < 9) {
                _easeLevel.SetValue(_easeLevel.Value + 1);
                _easeProgress.SetValue(0.0f);
                _easeLevelText.text = ((int)(_easeLevel.Value)).ToString();
                _easeLevelButton.GetComponentInChildren<Text>().text = ((int)(_easeLevel.Value)).ToString();
            }

            if (_userMoney.Value < _upgradeSkin.Price)
                _upgradeImage.color = Color.red;

        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (_upgradeSkin.IsAchieved) {

            // higlight image if playr has enough money
            if (_userMoney.Value >= _upgradeSkin.Price) {
                _upgradeImage.color = Color.grey;
            } else {
                _upgradeImage.color = Color.red;
            }

        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {

        if (_upgradeImage.color != Color.black)
            _upgradeImage.color = Color.white;

    }

    void Unlock()
    {
        // Broadcast all shop item info to screen
        _perClickProfit.text = String.Format("{0:f3}", _upgradeSkin.ClickProfit);
        _perSecondProfit.text = String.Format("{0:f3}", _upgradeSkin.AutoClickProfit);
        _upgradeName.text = _upgradeSkin.Name;
        _upgradeImage.sprite = _upgradeSkin.SkinSprite;
        _upgradeImage.color = Color.white;
        _upgradePrice.text = String.Format("{0:f3}", _upgradeSkin.Price);
    }

    void Start()
    {
        if (_upgradeSkin.IsAchieved) {
            Unlock();
        } else {
            _perClickProfit.text = "0";
            _perSecondProfit.text = "0";
            _upgradeName.text = "NOT ACHIEVED";
            _upgradeImage.sprite = _upgradeSkin.SkinSprite;
            _upgradeImage.color = Color.black;
            _upgradePrice.text = "UNKNOWN";
        }

        _bowlingLevelText.text = ((int)(_bowlingLevel.Value)).ToString();
        _easeLevelText.text = ((int)(_easeLevel.Value)).ToString();
        _bowlingLevelButton.GetComponentInChildren<Text>().text = ((int)(_bowlingLevel.Value)).ToString();
        _easeLevelButton.GetComponentInChildren<Text>().text = ((int)(_easeLevel.Value)).ToString();
        _moneyPerClickButton.GetComponentInChildren<Text>().text = String.Format("{0:f3}",
            _moneyPerClick.Value);
        _moneyPerSecondButton.GetComponentInChildren<Text>().text = String.Format("{0:f3}", _moneyPerSecond.Value);

    }

    void Update()
    {

        if (_upgradeImage.color == Color.black && _upgradeSkin.IsAchieved)
            Unlock();

    }
}
