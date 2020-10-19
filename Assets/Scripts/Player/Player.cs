using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;

public class Player : MonoBehaviour 
{
    private Saving savingScript;
    private Spawn spawnScript;
    public float coins;
    public bool coinsPlus;
    public float addCoins;
    public float coinTeilungsZahl;
    public float highScore;
    public float moveSpeed = 5f;
    private Vector2 moveInput;

    public float astroidSpeedS;
    public float astroidSpeed2S;
    public float kometSpeedS;
    public float scoreNumberS;
    public float addSpeedS;

    public int health;
    public int numOfHearts;
    public Image [] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int munition;
    public int numOfRockets;
    public Image [] rockets;
    public Sprite fullRocket;
    public Sprite emptyRocket;
    public int reloadTime;
    public float fillnmbr;
    public float maxFillnmbr;

    public float score;
    private float speedVRB;
    public float scoreNumber;
    public float addSpeed;

    private float checkPoint;
    public float astroidSpeed;
    public float kometSpeed;
    public float zahl;

 
    private bool freigabe;
    public GameObject rocketPrefab;
    public GameObject tryAgainPrefab;
    public GameObject tryAgainPrefab2;   
    public GameObject highScorePrefab;
    private Vector3 center;
    public bool tot;
    public bool anzeigen = false;

    public Touch touch;
    public Vector3 startPosition;
    public Vector3 touchPosition;
    public Vector3 richtung;
    public Touch touch2;
    public Vector3 startPosition2;
    public Vector3 touchPosition2;
    public Vector3 richtung2;
    public Vector3 rechteGrenze;
    public Vector3 screenPosition;
    public bool erlaubnisRechts;
    public bool erlaubnisLinks;
    public TextMeshProUGUI anzeige;
    private TextMeshProUGUI anzeigeHighScore;
    public bool geradeBerührt;
    public bool shieldActivated;
    public GameObject shieldPrefab;
    private GameObject shield;
    public int damage;
    public Vector3 shieldPosition;
    public float schildlaufzeit;
    public Vector3 test;
    public bool ready;
    public float astroidSpeed2;
    public int bin;
    public bool auferstanden;
    public GameObject timerPrefab;
    bool einmal;
    public bool res;
    public bool finnisteinspacko;
    private ShipSwitcher shipSwitcherscript;
    public bool shieldDestroy,shieldDestroy2;
    public bool anzeigeRevive, einzig;
    // Start is called before the first frame update
    void Start()
    {
        shipSwitcherscript = GameObject.Find("PlayerRocket").GetComponent<ShipSwitcher>();
        savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        spawnScript = GameObject.Find("Spawn").GetComponent<Spawn>();
        astroidSpeed = 4;
        InvokeRepeating("punkteZählen", 0, 0.1f);
        scoreNumber = 1;
        checkPoint = 10;
        freigabe = true;
        addSpeed = 2;
        zahl = 250;
        health = 3;
        numOfHearts = 3;

       erlaubnisLinks = true;
       erlaubnisRechts = true;

       coinsPlus = false;
       coinTeilungsZahl = 4;
       geradeBerührt = false;
       damage = 1;
       numOfRockets = 2;
       munition = numOfRockets;
       schildlaufzeit = 5;
       astroidSpeed2 = 0;
       auferstanden = false;
       res = false;
       finnisteinspacko = false;

       InvokeRepeating("RocketProgress", 0, 0.01f);
       einmal = false;
       shieldDestroy = false;
        // anzeigeHighScore = GameObject.FindGameObjectWithTag("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        bewegen();
        abschuss();
        schießen();
        healthManagement();
        rocketManagement();
        canvasÄndern();
        ende();
        schildAktivierung();
        shield = GameObject.FindGameObjectWithTag("Shield");
        revive();
       
         
    }
    void bewegen()
    {
       
       if(Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0f;
            touchPosition.z = 0f;
            screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            rechteGrenze.x = Screen.width -65;
            if(startPosition != center)
            {
                if (touchPosition != startPosition)
                {
                    if(screenPosition.x >= rechteGrenze.x)
                    {
                        erlaubnisRechts = false;
                        richtung = touchPosition - startPosition;
                    }
                    else if(screenPosition.x <= 65)
                    {
                        erlaubnisLinks = false;
                        richtung = touchPosition - startPosition;
                    }
                    else
                    {
                        erlaubnisRechts = true;
                        erlaubnisLinks = true;
                        richtung = touchPosition - startPosition;
                    }

                }
                startPosition = touchPosition;
            }
            else if(startPosition == center)
            {
                startPosition = touchPosition;
            }
        }
        else if(Input.touchCount == 0)
        {
            richtung = center;
            startPosition = center;
        }
        
        if(erlaubnisLinks == true && erlaubnisRechts == true)
        {
            transform.position += richtung * Time.deltaTime * moveSpeed;
        }
        else if(erlaubnisRechts == true && erlaubnisLinks == false && richtung.x > 0)
        {
            transform.position += richtung * Time.deltaTime * moveSpeed;
        }
        else if(erlaubnisRechts == false && erlaubnisLinks == true && richtung.x < 0)
        {
            transform.position += richtung * Time.deltaTime * moveSpeed;
        }
        else
        {
            richtung.x = 0;
        }
        

    }
    void abschuss()
    {

        if (Input.touchCount > 0)
        {
            
            touch2 = Input.GetTouch(0);
            touchPosition2 = Camera.main.ScreenToWorldPoint(touch2.position);
            touchPosition2.x = 0f;
            touchPosition2.z = 0f;
            if (startPosition2 != center)
            {
                if (touchPosition2 != startPosition2)
                {
                    richtung2 = touchPosition2 - startPosition2;

                    if (richtung2.y >0.2 && ready == true)
                    {
                       raketenAbschuss();
                       ready = false;
                    }
                }
                startPosition2 = touchPosition2;
            }
            else if (startPosition2 == center)
            {
                startPosition2 = touchPosition2;
            }
        }
        else if (Input.touchCount == 0)
        {
            richtung2 = center;
            startPosition2 = center;
        }
        if(richtung2.y == 0)
        {
            ready = true;
        }
    }
    public void raketenAbschuss()
    {
        if(fillnmbr >= 1000)
        {
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            munition--;
            fillnmbr = fillnmbr - 1000;
            StartCoroutine(waitSec10());
        }
    }
    IEnumerator waitSec10()
    {
        
        yield return new WaitForSeconds(reloadTime);
        if(munition < numOfRockets)
        {
            munition++;
        }
        

    }
    void schildAktivierung()
    {
        shieldPosition.x = transform.position.x +0.05f;
        shieldPosition.y = transform.position.y -1.2f;
        shieldPosition.z = 10;
        if(savingScript.shield > 0)
        {
            if(Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if(touch.phase ==TouchPhase.Began && geradeBerührt == true && shieldActivated == false )
                {
                    if(tot == false)
                    {
                        shieldActivated = true;
                        geradeBerührt = false;
                        savingScript.shield--;
                        StartCoroutine(schildLaufzeit());
                        GameObject clone =  Instantiate(shieldPrefab, shieldPosition, Quaternion.identity);
                    }
                }
                else if(geradeBerührt == false)
                {
                    StartCoroutine(waitSec2());
                    geradeBerührt = true;
                }
            }
        }
        IEnumerator schildLaufzeit()
        {
            for(int i = 0; i< 100; i++)
            {
                yield return new WaitForSeconds(schildlaufzeit/100);
                if(i == 68)
                {
                    shieldDestroy = true;
                }
                else if(i == 75)
                {
                    shieldDestroy = false;
                }
                else if(i == 82)
                {
                    shieldDestroy = true;
                }
                else if(i == 88)
                {
                    shieldDestroy = false;
                }
                else if(i == 92)
                {
                    shieldDestroy = true;
                }
                else if(i == 96)
                {
                    shieldDestroy = false;
                }
                 else if(i == 99)
                {
                    shieldDestroy = true;
                }
             

            }
            shieldActivated = false;
          shieldDestroy2 = true;
          shieldDestroy = false;

        }
       if(shieldActivated == true)
       {
           damage = 0;
       }
       else if(shieldActivated == false)
       {
           damage = 1;
       }

       
    }

    IEnumerator waitSec2()
    {
        yield return new WaitForSeconds(0.2f);
        geradeBerührt = false;
    }
    void punkteZählen()
    {
       
        speedVRB +=1;
        
        if(speedVRB > checkPoint && spawnScript.timerAbgelaufen == true && tot == false)
        {
            checkPoint += 10f;
            astroidSpeed += addSpeed/10;
            astroidSpeed2 += addSpeed/10;
            addSpeed = zahl/speedVRB;
            zahl = zahl /1.005f;
            scoreNumber = scoreNumber + 1 * astroidSpeed/10;
        }
        kometSpeed = astroidSpeed/3;
        score = score + astroidSpeed2/4;
    }

    void canvasÄndern()
    {
        float roundScore = Mathf.Round(score);
        anzeige.text =  roundScore.ToString();
    }
    
    void schießen()
    {
       
        if (Input.GetButton("Jump") == true && freigabe == true)
        {
            Instantiate(rocketPrefab, transform.position, Quaternion.identity);
            freigabe = false;
            StartCoroutine(waitSec());
        }

       
    }
    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(1f);
        freigabe = true;

    }
    
    void healthManagement()
    {
        if(health > numOfHearts)
         {
             health = numOfHearts;
         }
         for(int i = 0; i < hearts.Length; i++)
         {
             if(i< health)
             {
                 hearts[i].sprite = fullHeart;
             }
             else 
             {
                hearts[i].sprite = emptyHeart;
             }
             if(i < numOfHearts)
             {
                 hearts[i].enabled = true;
             }
             else 
             {
                 hearts[i].enabled = false;
             }
         }
    }
    void rocketManagement()
    {

        if(munition > numOfRockets)
         {
            munition = numOfRockets;
         }
         for(int i = 0; i < rockets.Length; i++)
         {
             if(i< munition)
             {
                rockets[i].sprite = fullRocket;
             }

             if(i < numOfRockets)
             {
                rockets[i].enabled = true;
             }
             else 
             {
                rockets[i].enabled = false;
             }
         }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Astroid")
        {
          
            health = health - damage;
            ende();
            if(shieldActivated == false)
            {
                Handheld.Vibrate();
            }
            
        }
        if(col.gameObject.tag == "Komet")
        {
            health = health-3 * damage;
            if(shieldActivated == false)
            {
                Handheld.Vibrate();
            }
           
        }
       
    }
    
    
    void ende()
    {
        if(tot == false)
        {
            astroidSpeedS = astroidSpeed;
            astroidSpeed2S = astroidSpeed2;
            kometSpeedS = kometSpeed;
            scoreNumberS = scoreNumber;
            addSpeedS = addSpeed;
            einzig = true;
        }
        else if(tot == true && einzig == true)
        {
            anzeigeRevive = false;
            einzig = false;
            
        }        
        einmal = false;
        if(health <= 0)
        {
            tot = true;
            health = 0;
            fillnmbr = 0;
            
        }
        if(tot == true && einmal == false)
        {
            astroidSpeed = 0;
            astroidSpeed2 = 0;
            kometSpeed = 0;
            scoreNumber = 0;
            addSpeed = 0;
            einmal = true;
            
           if(anzeigen == false && auferstanden == false)
            {
                anzeigen = true;
                auferstanden = true;
                Instantiate(tryAgainPrefab,center,Quaternion.identity);
            }
            else if(anzeigen == false && auferstanden == true)
            {
                anzeigen = true;
                Instantiate(tryAgainPrefab2,center,Quaternion.identity);
            }
            if(coinsPlus == false)
            {
                addCoins = Mathf.Round(score/coinTeilungsZahl);
                savingScript.coins =  savingScript.coins + addCoins;
                coinsPlus = true;
            }
            if(savingScript.highScore < score)
            {
                savingScript.highScore = score;
                Instantiate(highScorePrefab,center,Quaternion.identity);
            }
            
        }
    }

    public void revive()
    {
        if(res == true)
        {
            Instantiate(timerPrefab,center,Quaternion.identity);
            health = numOfHearts;
            spawnScript.dead = true;
            spawnScript.timerZahl = 3;
            spawnScript.einmalig = false;
            //anzeigen = false;
            res = false;
            anzeigeRevive = true;
        }
    }

    public void RocketProgress()
    {
        if (fillnmbr < maxFillnmbr && tot == false)
        {
            fillnmbr += 1f/reloadTime * 10 * bin;
        }
        if (fillnmbr <= 1000)
        {
            rockets[0].fillAmount = fillnmbr / 1000;
            rockets[1].fillAmount = 0;
            rockets[2].fillAmount = 0;
            rockets[3].fillAmount = 0;
        }
        else if (fillnmbr > 1000 && fillnmbr <= 2000)
        {
            rockets[1].fillAmount = (fillnmbr - 1000) / 1000;
            rockets[2].fillAmount = 0;
            rockets[3].fillAmount = 0;
        }
        else if (fillnmbr > 2000 && fillnmbr <= 3000)
        {
            rockets[2].fillAmount = (fillnmbr - 2000) / 1000;
            rockets[3].fillAmount = 0;
        }
        else if (fillnmbr > 3000 && fillnmbr <= 4000)
        {
            rockets[3].fillAmount = (fillnmbr - 3000) / 1000;
        }
    }

    public void battleShip()
    {
        switch (savingScript.shipLevel)
            {
                case 0:
                  Ship1();
                  savingScript.shipLevel = 1;
                    break;

                case 1:
                  Ship1();
                    break;

                case 2:
                  Ship2();
                    break;

                case 3:
                  Ship3();
                    break;

                default:
                   Destroy(gameObject);

                    break;
            }
    }
   
    public void Ship1()
    {
        reloadTime = 0;
        numOfRockets = 0;
        munition = numOfRockets;
        numOfHearts = 3;
        health = numOfHearts;
        maxFillnmbr = numOfRockets * 1000;
        shipSwitcherscript.shipNumber = 1;
        CapsuleCollider2D cc2d = GetComponent<CapsuleCollider2D>();
        cc2d.enabled = false;
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        bc2d.enabled = true;
        CircleCollider2D circlec2d = GetComponent<CircleCollider2D>();
        circlec2d.enabled = false;

    }

    public void Ship2()
    {
        reloadTime = 10;
        numOfRockets = 2;
        munition = numOfRockets;
        numOfHearts = 3;
        health = numOfHearts;
        maxFillnmbr = numOfRockets * 1000;
        shipSwitcherscript.shipNumber = 2;
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        bc2d.enabled = false;
        CapsuleCollider2D cc2d = GetComponent<CapsuleCollider2D>();
        cc2d.enabled = false;
        CircleCollider2D circlec2d = GetComponent<CircleCollider2D>();
        circlec2d.enabled = true;
        
    } 

    public void Ship3()
    {
        reloadTime = 8;
        numOfRockets = 3;
        munition = numOfRockets;
        numOfHearts = 4;
        health = numOfHearts;
        maxFillnmbr = numOfRockets * 1000;
        shipSwitcherscript.shipNumber = 3;
        BoxCollider2D bc2d = GetComponent<BoxCollider2D>();
        bc2d.enabled = false;
        CapsuleCollider2D cc2d = GetComponent<CapsuleCollider2D>();
        cc2d.enabled = true;
        CircleCollider2D circlec2d = GetComponent<CircleCollider2D>();
        circlec2d.enabled = false;
    } 
}
