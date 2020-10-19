using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
public class SceneSwipe : MonoBehaviour
{
    public Saving savingScript;
    public RectTransform MainUI, Shop, Options;
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    public Touch touch;
    public Vector3 test;
    public Vector3 startPosition;
    public Vector3 touchPosition;
    public Vector3 richtung;
    public Vector3 bewegungsRichtung;
    private Vector3 center;
    public int UIIndicator;
    public float sw;
    private RectTransform rt; 

    public float highScore;
    public float coins;
    Scene scene;
   // public TextMeshProUGUI anzeigeHighscore;
   // public TextMeshProUGUI anzeigeCoinsShop;
   // public TextMeshProUGUI anzeigeCoinsUI;

    // Start is called before the first frame update
    void Start()
    {
       // savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        rt = GameObject.Find("Canvas").GetComponent<RectTransform>();
        sw = rt.rect.width;
        MainUI.DOAnchorPos(Vector2.zero, 0.25f);
        Shop.DOAnchorPos(new Vector2(-sw, 0), 0.25f);
        Options.DOAnchorPos(new Vector2(sw, 0), 0.25f);
        UIIndicator = 1;
        scene = SceneManager.GetActiveScene();
        
    }
 private void Update ()
    {
        bewegen();
        if(Application.platform == RuntimePlatform.Android)
        {
            if(scene.name == "MainUI")
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    BackButton();
                }
            }
        }
    }
    public void ShopButton()
    {
        MainUI.DOAnchorPos(new Vector2(sw, 0), 0.25f);
        Shop.DOAnchorPos(new Vector2(0, 0), 0.25f);
        Options.DOAnchorPos(new Vector2(2*sw, 0), 0.25f);
        UIIndicator = 2;
    }

    public void BackButton()
    {
        MainUI.DOAnchorPos(new Vector2(0, 0), 0.25f);
        Shop.DOAnchorPos(new Vector2(-sw, 0), 0.25f);
        Options.DOAnchorPos(new Vector2(sw, 0), 0.25f);
        UIIndicator = 1;
    }

    public void OptionsButton()
    {
        MainUI.DOAnchorPos(new Vector2(-sw, 0), 0.25f);
        Shop.DOAnchorPos(new Vector2(2*-sw, 0), 0.25f);
        Options.DOAnchorPos(new Vector2(0, 0), 0.25f);
        UIIndicator = 3;
    }

    void bewegen()
    {

        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            test = touch.position;
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0f;
            touchPosition.z = 0f;
            if (startPosition != center)
            {
                if (touchPosition != startPosition)
                {
                        richtung = touchPosition - startPosition;

                    if (richtung.x > 0.2 && UIIndicator == 1)
                    {
                        ShopButton();
                    }
                    else if (richtung.x < -0.2 && UIIndicator == 2) 
                    {
                        BackButton();
                    }
                    else if (richtung.x < -0.2 && UIIndicator == 1)
                    {
                        BackButton();
                    }
                    else if (richtung.x < 0.2 && UIIndicator == 3)
                    {
                        BackButton();
                    }
                }
                startPosition = touchPosition;
            }
            else if (startPosition == center)
            {
                startPosition = touchPosition;
            }
        }
        else if (Input.touchCount == 0)
        {
            richtung = center;
            startPosition = center;
        }
    }
   
}
