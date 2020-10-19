using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawn : Zufall
{
    private Player playerScript;
    private Saving savingScript;
    public GameObject AstroidPrefab;
    public GameObject KometPrefab;
    
    public Vector3 center;
    public float zahl1;
    public float zahl2;

    private bool astroidTimer;
    private bool kometTimer;
    public float astroidSpawnRate;
    public float astroidSpawnAbstand;
    public float kometSpawnWahrscheinlichkeit;

    private bool astroidTimerS;
    private bool kometTimerS;
    public float astroidSpawnRateS;
    public float astroidSpawnAbstandS;
    public float kometSpawnWahrscheinlichkeitS;

    public bool zufallKomet;

    public float höhe;
    public float breite;

    private Vector3 spawn1;
    private Vector3 spawn2;

    private Vector3 punkt1;
    private Vector3 punkt2;
    public int timerZahl;
    public TextMeshProUGUI anzeigeTimerZahl;
    private TextMeshProUGUI anzeigeTimerZahl2;
    public bool einmalig;
    public bool timerAbgelaufen;
    public bool zuNah;
    public int reloadTime;
    public bool dead;
    Scene scene;
    bool back;

   
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        //anfangsspawnrate = 1
        astroidSpawnRate = 0f;
        // anfangswahrscheinlichkeit = 30
        kometSpawnWahrscheinlichkeit = 0;
       
        InvokeRepeating("astroidSpawnRateÜberprüfen",0, 1f);
        InvokeRepeating("spawnKomet",0f, 0.1f);
        InvokeRepeating("startTimer", 0f,1f);
        InvokeRepeating("reviveTimer", 0f,1f);
        StartCoroutine(astroidWaitsec());
        timerZahl = 4;
        einmalig = false;
        timerAbgelaufen = false;
        zuNah = false;
       // playerScript.astroidSpeed = 0;
       reloadTime = playerScript.reloadTime;
       dead = false;
       scene = SceneManager.GetActiveScene();
       back = false;
    }

    // Update is called once per frame
    void Update()
    {
        höhe = Screen.height;
        breite = Screen.width;

        punkt1.x = breite;
        punkt1.y = höhe;

        punkt2.x = 0;
        punkt2.y = höhe;
        
        spawn1 = Camera.main.ScreenToWorldPoint(punkt1);
        spawn2 = Camera.main.ScreenToWorldPoint(punkt2);
        spawnAstroid();
        if(Application.platform == RuntimePlatform.Android)
        {
            if(scene.name == "GameScene")
            {
                if(Input.GetKeyDown(KeyCode.Escape) && back == false)
                {
                    back = true;
                    StartCoroutine(backButton());
                }
                else if(Input.GetKeyDown(KeyCode.Escape) && back == true)
                {
                    back = false;
                    SceneManager.LoadScene("MainUI");
                }
            }

        }
    }
    IEnumerator backButton()
    {
        yield return new WaitForSeconds(1f);
        back = false;
    }
    
    void astroidSpawnRateÜberprüfen()
    {
        if(playerScript.score >= 0)
        {
            if(astroidSpawnRate < 3f)
            {
                astroidSpawnRate = astroidSpawnRate + 0.01025f;
            }
        }
    }
    
    IEnumerator astroidWaitsec()
    {
        if(astroidSpawnRate> 0)
        {
            if (astroidTimer == false)
            {
                astroidSpawnAbstand = 0.8f/astroidSpawnRate;
                yield return new WaitForSeconds(astroidSpawnAbstand);
                astroidTimer = true;
            }
            
        }
        else if(astroidSpawnRate == 0)
        {
            yield return new WaitForSeconds(5f);
            StartCoroutine(astroidWaitsec());
        }
    }
    public void spawnAstroid()
    {
        if (astroidTimer == true && playerScript.tot == false)
        {
            zahl1 = zzGenerieren1(spawn1.x -0.16f, spawn2.x + 0.16f);

            Vector3 pos = center + new Vector3(zahl1, spawn1.y + 1, 0);
            Instantiate(AstroidPrefab, pos, Quaternion.identity);
            astroidTimer = false;
            StartCoroutine(astroidWaitsec());
        }
    }

    public void spawnKomet()
    {
        float zahl3 = zzGenerieren1(0,kometSpawnWahrscheinlichkeit);
        if( zahl3 > 29)
        {
            zufallKomet = true;
        }
        if (playerScript.tot == false && zufallKomet == true && zuNah == false)
        {
            zahl2 = zzGenerieren1(spawn1.x - 0.6f, spawn2.x+0.6f);

            Vector3 pos = center + new Vector3(zahl2, spawn1.y + 1, 0);
            Instantiate(KometPrefab, pos, Quaternion.identity);
            zufallKomet = false;
            zuNah = true;
            StartCoroutine(warteZeit());
        }
    }
    IEnumerator warteZeit()
    {     
        yield return new WaitForSeconds(1f);
        zuNah = false;
    }
    public void startTimer()
    {
        playerScript.scoreNumber = 0;
       
        
        
        if(timerZahl>1)
        {
            timerZahl--;
            anzeigeTimerZahl.text =  timerZahl.ToString();
            playerScript.bin = 0;
        }
        else if(timerZahl == 1 && einmalig == false)
        {
            astroidSpawnRate = 1f;
            kometSpawnWahrscheinlichkeit = 30;
            einmalig= true;
            Destroy(anzeigeTimerZahl);
            timerAbgelaufen = true;
            playerScript.reloadTime = reloadTime;
            playerScript.bin = 1;
            CancelInvoke("startTimer");
        }
    }

    public void reviveTimer()
    {
        if(dead == true)
        {
            kometSpawnWahrscheinlichkeitS = kometSpawnWahrscheinlichkeit;
            astroidSpawnRateS = astroidSpawnRate;
                  
        
            if(timerZahl>=1)
            {
                timerZahl--;
                anzeigeTimerZahl2.text = timerZahl.ToString();
                playerScript.bin = 0;
                playerScript.scoreNumber = 0;
                playerScript.anzeigeRevive = true;
            }
            else if(timerZahl == 0 && einmalig == false)
            {
                astroidSpawnRate = astroidSpawnRateS;
                kometSpawnWahrscheinlichkeit = kometSpawnWahrscheinlichkeitS;
                einmalig= true;
                
                timerAbgelaufen = true;
                playerScript.reloadTime = reloadTime;
                playerScript.bin = 1;

                playerScript.astroidSpeed = playerScript.astroidSpeedS;
                playerScript.astroidSpeed2 = playerScript.astroidSpeed2S;
                playerScript.kometSpeed = playerScript.kometSpeedS;
                playerScript.scoreNumber = playerScript.scoreNumberS;
                playerScript.addSpeed = playerScript.addSpeedS;
                //playerScript.health = playerScript.numOfHearts;
                playerScript.anzeigen = false;
                savingScript.coins =  savingScript.coins - playerScript.addCoins;
                playerScript.coinsPlus = false;
                playerScript.tot = false;
                Destroy(anzeigeTimerZahl2);
            }
        }
    }
   

       
  
   
}
