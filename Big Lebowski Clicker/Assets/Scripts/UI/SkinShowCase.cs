using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinShowCase : MonoBehaviour
{
    [SerializeField] private BasicSkin[] Skins;
    public GameObject ShowCase;
    public GameObject OnEnteredShowCase;
    [SerializeField] private BasicBool _skinActive;

    public float timer = 0.0f;
    public float delay = 1.3f;

    public int skinPos = 0;

    Color redColor = Color.HSVToRGB(1.0f, 0.3820755f, 0.3820755f);

    void Start()
    {
        _skinActive.SetValue(false);
        ShowCase.GetComponent<SpriteRenderer>().sprite = Skins[0].SkinSprite;
        OnEnteredShowCase.GetComponent<SpriteRenderer>().sprite = Skins[0].SkinSprite;

    }

    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= delay) {

            timer = 0; 

            skinPos = (skinPos + 1) % Skins.Length;

            ShowCase.GetComponent<SpriteRenderer>().sprite = Skins[skinPos].SkinSprite;
            OnEnteredShowCase.GetComponent<SpriteRenderer>().sprite = Skins[skinPos].SkinSprite;

            if (Skins[skinPos].IsReached && !Skins[skinPos].IsAchieved) {
                
                OnEnteredShowCase.GetComponent<SpriteRenderer>().color = redColor;
                ShowCase.GetComponent<SpriteRenderer>().color = Color.white;

                if (_skinActive.Value) {
                    OnEnteredShowCase.SetActive(true);
                    ShowCase.GetComponent<SpriteRenderer>().color = Color.grey;
                }

            } else if (!Skins[skinPos].IsAchieved) {

                OnEnteredShowCase.GetComponent<SpriteRenderer>().color = Color.black;
                ShowCase.GetComponent<SpriteRenderer>().color = Color.black;
                
                if (_skinActive.Value) 
                    OnEnteredShowCase.SetActive(false); 

            } else {

                OnEnteredShowCase.GetComponent<SpriteRenderer>().color = Color.white;
                ShowCase.GetComponent<SpriteRenderer>().color = Color.white;

                if (_skinActive.Value) {
                    OnEnteredShowCase.SetActive(true);
                    ShowCase.GetComponent<SpriteRenderer>().color = Color.grey;
                }
            }
        }
        
    } 

}
