using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class LocationShowCase : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] private BasicSkin[] _locationsSkins;
    [SerializeField] private GameObject[] _locations; // different scenes, dedicated to locations
    [SerializeField] WholeStat _curLocationPos; 
    [SerializeField] private BasicBool _locationActive;

    public GameObject _locationShowCase;
    public GameObject _locationOnEnteredShowCase;

    public float timer = 0.0f;
    public float delay = 1.3f;

    Color redColor = Color.HSVToRGB(1.0f, 0.3820755f, 0.3820755f);
    private Color lastColor = Color.white;

    public int skinPos = 0;

    void Start()
    {
        _locationActive.SetValue(false);
        for (int i = 0; i < _locations.Length; i++)
            if (i == (int)_curLocationPos.Value)
                _locations[i].SetActive(true);
            else
                _locations[i].SetActive(false);

        _locationShowCase.GetComponent<SpriteRenderer>().sprite = _locationsSkins[0].SkinSprite;
        _locationOnEnteredShowCase.GetComponent<SpriteRenderer>().sprite = _locationsSkins[0].SkinSprite;

    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= delay) {

            timer = 0;

            skinPos = (skinPos + 1) % _locationsSkins.Length;

            _locationShowCase.GetComponent<SpriteRenderer>().sprite = _locationsSkins[skinPos].SkinSprite;
            _locationOnEnteredShowCase.GetComponent<SpriteRenderer>().sprite = _locationsSkins[skinPos].SkinSprite;

            if (!_locationsSkins[skinPos].IsAchieved && _locationsSkins[skinPos - 1].IsAchieved) {

                _locationOnEnteredShowCase.GetComponent<SpriteRenderer>().color = redColor;
                _locationShowCase.GetComponent<SpriteRenderer>().color = Color.white;

                if (_locationActive.Value) {
                    _locationOnEnteredShowCase.SetActive(true);
                    _locationShowCase.GetComponent<SpriteRenderer>().color = Color.grey;
                }

            } else if (!_locationsSkins[skinPos].IsAchieved && !_locationsSkins[skinPos - 1].IsAchieved) {

                _locationOnEnteredShowCase.GetComponent<SpriteRenderer>().color = Color.black;
                _locationShowCase.GetComponent<SpriteRenderer>().color = Color.black;

                if (_locationActive.Value)
                    _locationOnEnteredShowCase.SetActive(false);

            } else {

                _locationOnEnteredShowCase.GetComponent<SpriteRenderer>().color = Color.white;
                _locationShowCase.GetComponent<SpriteRenderer>().color = Color.white;

                if (_locationActive.Value) {
                    _locationOnEnteredShowCase.SetActive(true);
                    _locationShowCase.GetComponent<SpriteRenderer>().color = Color.grey;
                }

            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _locationActive.SetValue(true);
        lastColor = _locationShowCase.GetComponent<SpriteRenderer>().color;

        if (_locationOnEnteredShowCase.GetComponent<SpriteRenderer>().color != Color.black) {
            _locationShowCase.GetComponent<SpriteRenderer>().color = Color.gray;
            _locationOnEnteredShowCase.SetActive(true);
        }
    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _locationActive.SetValue(false); 
        _locationOnEnteredShowCase.SetActive(false);
        if (_locationOnEnteredShowCase.GetComponent<SpriteRenderer>().color != Color.black)
            _locationShowCase.GetComponent<SpriteRenderer>().color = Color.white;

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (_locationOnEnteredShowCase.GetComponent<SpriteRenderer>().color != redColor && _locationOnEnteredShowCase.GetComponent<SpriteRenderer>().color != Color.black) {
            _locations[(int)_curLocationPos.Value].SetActive(false);
            _curLocationPos.SetValue(skinPos);
            _locations[(int)_curLocationPos.Value].SetActive(true);
        }

    }
}
