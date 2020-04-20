using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStartClear : MonoBehaviour
{

    // dumb way to handle game's first run

    [SerializeField] private BasicBool _firstStart;
    [SerializeField] private Skin _mainSkin;
    [SerializeField] private WholeStat _userMoney;
    [SerializeField] private BasicSkin[] _skins;
    [SerializeField] private UpgradeSkin[] _upgSkins;
    [SerializeField] private BasicSkin _secondSkin, _secondLocation;
    [SerializeField] private MoneyStat _moneyPerClick;
    [SerializeField] private MoneyStat _moneyPerSecond;
    [SerializeField] private WholeStat _bowlingLevel;
    [SerializeField] private WholeStat _currectLocation;
    [SerializeField] private WholeStat _easeLevel;
    [SerializeField] private NormalizedStat _bowlingProgress;
    [SerializeField] private NormalizedStat _easeProgress;
    [SerializeField] private Sprite _mainSprite;

    [SerializeField] private Text _bowlingLevelText;
    [SerializeField] private Text _easeLevelText;
    [SerializeField] private Button _bowlingLevelButton;
    [SerializeField] private Button _easeLevelButton;

    [SerializeField] private Button _moneyPerClickButton;
    [SerializeField] private Button _moneyPerSecondButton;

    void Start()
    {

        if (_firstStart.Value == true) {

            _firstStart.SetValue(false);
            _mainSkin.SetSprite(_mainSprite);
            _userMoney.SetValue(100);

            _moneyPerClickButton.GetComponentInChildren<Text>().text = "3,000";
            _moneyPerSecondButton.GetComponentInChildren<Text>().text = "1,000";

            _bowlingLevelText.text = "1";
            _easeLevelText.text = "1";
            _bowlingLevelButton.GetComponentInChildren<Text>().text = "1";
            _easeLevelButton.GetComponentInChildren<Text>().text = "1";
            
            for (int i = 0; i < _skins.Length; i++) {

                _skins[i].Achieve(false);
                _skins[i].Reach(false);

            }

            for (int i = 0; i < _upgSkins.Length; i++) {

                if (i > 0) // first player's skin is always achieved
                    _upgSkins[i].Achieve(false); 

                for (int j = 0; j < _upgSkins[i].Iterations; j++) {

                    _upgSkins[i].SetAutoClickProfit(_upgSkins[i].AutoClickProfit / 1.1f);
                    _upgSkins[i].SetClickProfit(_upgSkins[i].ClickProfit / 1.2f);
                    _upgSkins[i].SetBowlingProfit(_upgSkins[i].BowlingProfit / 0.9f);
                    _upgSkins[i].SetEaseProfit(_upgSkins[i].EaseProfit / 0.9f);
                    _upgSkins[i].SetPrice(_upgSkins[i].Price / 1.5f);

                }

                _upgSkins[i].SetIterations(0);

            }

            _secondLocation.Reach();
            _secondSkin.Reach();

            _moneyPerClick.SetValue(3);
            _moneyPerSecond.SetValue(1);
            _bowlingLevel.SetValue(1);
            _currectLocation.SetValue(0);
            _easeLevel.SetValue(1);
            _bowlingProgress.SetValue(0.0f);
            _easeProgress.SetValue(0.0f);
            

        }
        
    }
}
