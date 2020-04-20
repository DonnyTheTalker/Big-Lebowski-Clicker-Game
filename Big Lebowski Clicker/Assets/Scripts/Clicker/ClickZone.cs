using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ClickZone : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private WholeStat _money; // total player's money
    [SerializeField] private MoneyStat _click; // money per click
    [SerializeField] private MoneyStat _autoClick; // mmoney per second
    [SerializeField] private Button _moneyBotton;
    [SerializeField] private Button _moneyClickBotton;
    [SerializeField] private Button _moneySecondBotton;
    [SerializeField] private ParticleSystem _coinParticle;

    float time = 0f, delta = 1f; // calculating time to add money per second value

    public void OnPointerClick(PointerEventData eventData)
    {

        _money.SetValue(_money.Value + _click.Value);

        _coinParticle.Emit(Math.Min(5, (int)_click.Value / 10 + 1));
        _coinParticle.GetComponent<ParticleSystem>().Play();

        _money.CheckOverflow();

        SetButtonText();

    }

    void Start()
    {

        _click.ChangeButtonValue(_moneyClickBotton);
        _autoClick.ChangeButtonValue(_moneySecondBotton);

    }

    void Update()
    {

        time += Time.deltaTime;

        if (time >= delta) {

            time = 0;
            _money.SetValue(_money.Value + _autoClick.Value);

            _money.CheckOverflow();

            SetButtonText(); 

        }

    }

    private void SetButtonText() // changing money botton text
    {

        _moneyBotton.GetComponentInChildren<Text>().text = ((int)(_money.Value)).ToString();

    }

}
