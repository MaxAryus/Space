using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Saving : MonoBehaviour
{
   public float coins;
   public float highScore;
    public float shield;
    public float doubleCoins;
    public float slow;
    public int shipLevel;

   public TextMeshProUGUI anzeigeHighscore;
    public TextMeshProUGUI anzeigeCoinsShop;
    public TextMeshProUGUI anzeigeCoinsUI;
    public TextMeshProUGUI anzeigeShield;
    public TextMeshProUGUI anzeigeDoubleCoins;
    public TextMeshProUGUI anzeigeSlow;
    public TextMeshProUGUI anzeigeShip1,anzeigeShip2,anzeigeShip3;
    private GameObject xButton,yButton;
    public bool ship1,ship2,ship3;
    private Player playerScript;
    public int  expireDate,date;
    public bool DailyRewardedVideo;
    public bool ready,once;
    
    void Start()
    {
        if(once == false)
        {
            ready = true;
            once = true;
        }
        ship1 = true;
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        LoadData();
        xButton = GameObject.Find("Double");
        yButton = GameObject.Find("Slow");
        if(doubleCoins <= 0)
        {
            Destroy(xButton);
        }
        if(slow <= 0)
        {
            Destroy(yButton);
        }   
        StartCoroutine(waitSec());
        playerScript.battleShip();
    }

    // Update is called once per frame
    void Update()
    {
        SaveData();
        canvasÄndern();
        equipment();
    }
    public void LoadData()
    {
        Data data = SaveSystem.LoadData();
        coins = data.coins;
        highScore = data.highScore;
        shield = data.shield;
        doubleCoins = data.doubleCoins;
        slow = data.slow;
        shipLevel = data.shipLevel;
              
        ship1 = data.ship1;
        ship2 = data.ship2;
        ship3 = data.ship3;
        expireDate = data.expireDate;
        date = data.date;
        DailyRewardedVideo = data.DailyRewardedVideo;
        ready = data.ready;
        once = data.once;
    
    }
    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

     public void canvasÄndern()
    {
       float roundHighScore = Mathf.Round(highScore);
       anzeigeHighscore.text =  roundHighScore.ToString();

        float roundCoins = Mathf.Round(coins);
        anzeigeCoinsShop.text = roundCoins.ToString();
        anzeigeCoinsUI.text = roundCoins.ToString();  
        anzeigeShield.text = ("In Besitz: "+ shield.ToString());
        anzeigeDoubleCoins.text = ("In Besitz: "+ doubleCoins.ToString());
        anzeigeSlow.text = ("In Besitz: "+ slow.ToString());
    }
     IEnumerator waitSec()
    {
        yield return new WaitForSeconds(5f);
        Destroy(xButton);
    }

    public void equipment()
    {
        if( shipLevel == 1)
        {
            anzeigeShip1.text = "Equipped!";
        }
        else if(shipLevel != 1)
        {
            anzeigeShip1.text = "Equip?";
        }

        if(ship2 == true && shipLevel == 2)
        {
            anzeigeShip2.text = "Equipped!";
        }
        else if(ship2 == true && shipLevel != 2)
        {
            anzeigeShip2.text = "Equip?";
        }
        if(ship3 == true && shipLevel == 3)
        {
            anzeigeShip3.text = "Equipped!";
        }
        else if(ship3 == true && shipLevel != 3)
        {
            anzeigeShip3.text = "Equip?";
        }
        
    }
}
