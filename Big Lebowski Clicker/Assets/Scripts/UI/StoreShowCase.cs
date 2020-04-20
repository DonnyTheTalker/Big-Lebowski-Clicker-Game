using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreShowCase : MonoBehaviour, IPointerClickHandler,
    IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private Sprite[] _shopImages;
    [SerializeField] private GameObject _skinShowCase;

    float delay = 1.3f;
    float time = 0;
    int skinPos = 0;

    public void OnPointerClick(PointerEventData eventData)
    {
        _shopPanel.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // highlight store image
        _skinShowCase.GetComponent<SpriteRenderer>().color = Color.gray;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _skinShowCase.GetComponent<SpriteRenderer>().color = Color.white;
    }

    void Start()
    {
        _shopPanel.SetActive(false);
    }


    void Update()
    {
        time += Time.deltaTime;

        if (time >= delay) {

            time = 0;
            skinPos = Random.Range(1, _shopImages.Length - 1); // random store image from possible list
            _skinShowCase.GetComponent<SpriteRenderer>().sprite = _shopImages[skinPos];

        }

    }
}
