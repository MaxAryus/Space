using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Button : Zufall
{

    public Touch touch;
    public Vector3 test;
    public Vector3 startPosition;
    public Vector3 touchPosition;
    public Vector3 richtung;
    public Vector3 bewegungsRichtung;
    public Vector3 linkeGrenze;
    public Vector3 rechteGrenze;
    public Vector3 hallo1;
    public Vector3 hallo2;
    public bool erlaubnisRechts;
    public bool erlaubnisLinks;
    public int Shield;
    public int Slow;
    public int doubleCoins;
   // private SceneSwipe ss;
    private Saving savingScript;
    public GameObject rocketPrefab;
    private bool freigabe;
    private Transform playerTransform;
    private Player playerScript;
    private float astroidSpeed;
    private bool slowActivated;
    public Image clock;
    public GameObject LootBoxContent;
    public Vector3 center;
    public string content;
    public float zz;
    public float zzz;
    public int zzzz;
    public bool daily;
    private Image zlowButtonImage;
    Scene scene;
   
    // Start is called before the first frame update
    void Start()
    {
        zlowButtonImage = GameObject.Find("Slow").GetComponent<Image>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        //ss = GameObject.Find("SceneSwipe").GetComponent<SceneSwipe>();
        savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        freigabe = true;
        slowActivated = false;
        
        InvokeRepeating("slowCount", 0, 0.01f);
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
            test = touch.position;
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.y = 0f;
            touchPosition.z = 0f;
            hallo1 = transform.position;
            hallo2 = Camera.main.WorldToScreenPoint(transform.position);
        }
        if(daily == true)
        {
            videoLootbox();
        }

        
        if(scene.name == "GameScene")
        {
            if(playerScript.tot == true)
            {
                zlowButtonImage.enabled = false;
            }
            else if(playerScript.tot == false )
            {
                zlowButtonImage.enabled = true;
            }

            if(playerScript.anzeigeRevive == true)
            {
                zlowButtonImage.enabled = true;
            }
        }
        

    }
    
    public void tryAgain()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void PlayBtn()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("MainUI");
    }
    

    public void buyShieldBtn()
    {
        if (savingScript.coins >= 800)
        {
        savingScript.coins = savingScript.coins-800;
        savingScript.shield++;
        }
    }
    public void buyDoubleCoinBtn()
    {
        if (savingScript.coins >= 600)
        {
        savingScript.coins = savingScript.coins-600;
        savingScript.doubleCoins++;
        }
    }
    public void doubleCoinButton()
    {
        if(savingScript.doubleCoins >= 1 && playerScript.tot == false)
        {
            playerScript.coinTeilungsZahl = playerScript.coinTeilungsZahl/2;
            savingScript.doubleCoins--;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void slowButton()
    {
        if(savingScript.slow >=1)
        {
            if(slowActivated == false)
            {
            astroidSpeed = playerScript.astroidSpeed;
            playerScript.astroidSpeed = astroidSpeed/2;
            StartCoroutine(slowTimer());
            savingScript.slow--;
            slowActivated= true;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    IEnumerator slowTimer()
    {
        yield return new WaitForSeconds(5f);
        float speed = playerScript.astroidSpeed-astroidSpeed/2;
        playerScript.astroidSpeed = astroidSpeed + speed;
        slowActivated = false;

    }
    public void slowCount()
    {
        if(slowActivated == true && playerScript.tot == false)
        {
            clock.fillAmount -= 0.002f;
        }
        else if(slowActivated == false)
        {
            clock.fillAmount = 1;
        }
        
    }
   
    public void buyslowBtn()
    {
        if (savingScript.coins >= 400)
        {
        savingScript.coins = savingScript.coins-400;
        savingScript.slow++;
        }
    }

    public void buyShip1()
    {
        savingScript.shipLevel = 1;
    }

     public void buyShip2()
    {
        if(savingScript.coins >= 25000 && savingScript.ship2 == false)
        {
            savingScript.coins = savingScript.coins -25000;
            savingScript.shipLevel = 2;
            savingScript.ship2 = true;
        }
        else if(savingScript.ship2 == true)
        {
            savingScript.shipLevel = 2;
        }
    }

    public void buyShip3()
    {
        if(savingScript.coins >= 50000 && savingScript.ship3 == false)
        {
            savingScript.coins = savingScript.coins -50000;
            savingScript.shipLevel = 3;
            savingScript.ship3 = true;
            
        }
        else if(savingScript.ship3 == true)
        {
            savingScript.shipLevel = 3;
        }
    }
    public void Geld()
    {
        savingScript.coins+=10000;
    }
    
    public void cheapLootbox()
    {
        
        if(savingScript.coins >= 1000)
        {
            savingScript.coins = savingScript.coins - 1000;
            zz = zzGenerieren2(1f,100f);
            zzz = zzGenerieren1(1f,100f);
            zzzz = zzGenerieren3 (1,4);
            
            if(zz <= 49.5f)
            {
                if(zzz <= 20f)
                {
                    savingScript.coins = savingScript.coins + 300f;
                    content = "300 Coins";
                }
                else if(zzz>20f && zzz <= 60f)
                {
                    savingScript.coins = savingScript.coins + 500f;
                    content = "500 Coins";
                }
                else if(zzz>60f && zzz <= 86f)
                {
                    savingScript.coins = savingScript.coins + 1000f;
                    content = "1000 Coins";
                }
                else if(zzz<86f)
                {
                    savingScript.coins = savingScript.coins + 2000f;
                    content = "2000 Coins";
                }
            }
            else if(zz >49.5f && zz <=99f)
            {
                if(zzz <= 60f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+1;
                        content = "1 Shield-Ability";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +1;
                        content = "1 Slow-Ability";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +1;
                        content = "1 doubleCoin-Ability";
                    }
                }
                else if(zzz>60f && zzz <= 80f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+ 2f;
                        content = "2 Shield-Abilitys";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +2f;
                        content = "2 Slow-Abilitys";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +2f;
                        content = "2 doubleCoin-Abilitys";
                    }
                }
                else if(zzz>80f && zzz <= 95f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+3f;
                        content = "3 Shield-Abilitys";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +3f;
                        content = "3 Slow-Abilitys";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +3f;
                        content = "3 doubleCoin-Abilitys";
                    }
                }
                else if(zzz<95f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+4f;
                        content = "4 Shield-Abilitys";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +4f;
                        content = "3 Slow-Abilitys";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +4f;
                        content = "4 doubleCoin-Abilitys";
                    }
                }
            }
            else if(zz> 99f)
            {
                if(zzz <= 35f)
                {
                    savingScript.ship1 = true;
                    content = "Ship 1 ";
                }
                else if(zzz>35f && zzz <= 65f)
                {
                    savingScript.ship2 = true;
                    content = "Ship 2 ";
                }
                else if(zzz>65f && zzz <= 80f)
                {
                    savingScript.ship3 = true;
                    content = "Ship 3 ";
                }
                else if(zzz> 80f && zzz<= 100f)
                {
                    savingScript.coins += 3000;
                }
            }
        Instantiate(LootBoxContent, center, Quaternion.identity);
        }
    }

    

    public void expensiveLootbox()
    {
        
        if(savingScript.coins >= 5000)
        {
            savingScript.coins = savingScript.coins - 5000;
            zz = zzGenerieren2(1f,100f);
            zzz = zzGenerieren1(1f,100f);
            zzzz = zzGenerieren3 (1,4);
            
            if(zz <= 49.5f)
            {
                if(zzz <= 35f)
                {
                    savingScript.coins = savingScript.coins + 2000;
                    content = "2000 Coins";
                }
                else if(zzz>35f && zzz <= 70f)
                {
                    savingScript.coins = savingScript.coins + 5000;
                    content = "5000 Coins";
                }
                else if(zzz>70f && zzz <= 90f)
                {
                    savingScript.coins = savingScript.coins + 10000;
                    content = "10000 Coins";
                }
                else if(zzz>86f)
                {
                    savingScript.coins = savingScript.coins + 20000f;
                    content = "20000 Coins";
                }
            }
            else if(zz >49.5f && zz <=99f)
            {
                if(zzz <= 50f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+3;
                        content = "3 Shield-Abilitys";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +3;
                        content = "3 Slow-Abilitys";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +3;
                        content = "3 doubleCoin-Abilitys";
                    }
                }
                else if(zzz>50f && zzz <= 70f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+ 5f;
                        content = "5 Shield-Abilitys";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +5f;
                        content = "5 Slow-Abilitys";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +5f;
                        content = "5 doubleCoin-Abilitys";
                    }
                }
                else if(zzz>70f && zzz <= 90f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+10f;
                        content = "10 Shield-Abilitys";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +10f;
                        content = "10 Slow-Abilitys";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +10f;
                        content = "10 doubleCoin-Abilitys";
                    }
                }
                else if(zzz>90f)
                {
                    if(zzzz ==1)
                    {
                        savingScript.shield = savingScript.shield+15f;
                        content = "15 Shield-Abilitys";
                    }
                    else if (zzzz ==2)
                    {
                        savingScript.slow = savingScript.slow +15f;
                        content = "15 Slow-Abilitys";
                    }
                    else if( zzzz ==3)
                    {
                        savingScript.doubleCoins = savingScript.doubleCoins +15f;
                        content = "15 doubleCoin-Abilitys";
                    }
                }
            }
            else if(zz> 99f)
            {
                if(zzz <= 45f)
                {
                    savingScript.ship1 = true;
                    content = "Ship 1 ";
                }
                else if(zzz>45f && zzz <= 80f)
                {
                    savingScript.ship2 = true;
                    content = "Ship 2 ";
                }
                else if(zzz>80f && zzz <= 100f)
                {
                    savingScript.ship3 = true;
                    content = "Ship 3 ";
                }
            }
        Instantiate(LootBoxContent, center, Quaternion.identity);
        }
    }


    public void videoLootbox()
    {
       
        zz = zzGenerieren2(1f,100f);
        zzz = zzGenerieren1(1f,100f);
        zzzz = zzGenerieren3 (1,4);
            
        if(zz <= 49.5f)
        {
            if(zzz <= 35f)
            {
                savingScript.coins = savingScript.coins + 2000;
                content = "2000 Coins";
            }
            else if(zzz>35f && zzz <= 70f)
            {
                savingScript.coins = savingScript.coins + 5000;
                content = "5000 Coins";
            }
            else if(zzz>70f && zzz <= 90f)
            {
                savingScript.coins = savingScript.coins + 10000;
                content = "10000 Coins";
            }
            else if(zzz>86f)
            {
                savingScript.coins = savingScript.coins + 20000f;
                content = "20000 Coins";
            }
            }
        else if(zz >49.5f && zz <=99f)
        {
            if(zzz <= 50f)
            {
                if(zzzz ==1)
                {
                    savingScript.shield = savingScript.shield+3;
                    content = "3 Shield-Abilitys";
                }
                else if (zzzz ==2)
                {
                    savingScript.slow = savingScript.slow +3;
                    content = "3 Slow-Abilitys";
                }
                else if( zzzz ==3)
                {
                    savingScript.doubleCoins = savingScript.doubleCoins +3;
                    content = "3 doubleCoin-Abilitys";
                }
            }
            else if(zzz>50f && zzz <= 70f)
            {
                if(zzzz ==1)
                {
                    savingScript.shield = savingScript.shield+ 5f;
                    content = "5 Shield-Abilitys";
                }
                else if (zzzz ==2)
                {
                    savingScript.slow = savingScript.slow +5f;
                    content = "5 Slow-Abilitys";
                }
                else if( zzzz ==3)
                {
                    savingScript.doubleCoins = savingScript.doubleCoins +5f;
                    content = "5 doubleCoin-Abilitys";
                }
            }
            else if(zzz>70f && zzz <= 90f)
            {
                if(zzzz ==1)
                {
                    savingScript.shield = savingScript.shield+10f;
                    content = "10 Shield-Abilitys";
                }
                else if (zzzz ==2)
                {
                    savingScript.slow = savingScript.slow +10f;
                    content = "10 Slow-Abilitys";
                }
                else if( zzzz ==3)
                {
                    savingScript.doubleCoins = savingScript.doubleCoins +10f;
                    content = "10 doubleCoin-Abilitys";
                }
                }
            else if(zzz>90f)
            {
                if(zzzz ==1)
                {
                    savingScript.shield = savingScript.shield+15f;
                    content = "15 Shield-Abilitys";
                }
                else if (zzzz ==2)
                {
                    savingScript.slow = savingScript.slow +15f;
                    content = "15 Slow-Abilitys";
                }
                else if( zzzz ==3)
                {
                    savingScript.doubleCoins = savingScript.doubleCoins +15f;
                    content = "15 doubleCoin-Abilitys";
                }
            }
        }
        else if(zz> 99f)
        {
            if(zzz <= 45f)
            {
                savingScript.ship1 = true;
                content = "Ship 1 ";
            }
            else if(zzz>45f && zzz <= 80f)
            {
                savingScript.ship2 = true;
                content = "Ship 2 ";
            }
            else if(zzz>80f && zzz <= 100f)
            {
                savingScript.ship3 = true;
                content = "Ship 3 ";
            }
        }
        daily = false;
        Instantiate(LootBoxContent, center, Quaternion.identity);
    }


    
}
