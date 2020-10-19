using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data 
{
   public float coins;
   public float highScore;
   public float shield;
   public float doubleCoins;
   public float slow;
   public int shipLevel;
   public bool ship1,ship2,ship3;
   public bool [] ship;
   public bool DailyRewardedVideo;
   public int  expireDate,date;
   public bool ready,once;

   public Data (Saving saving)
   {
       coins = saving.coins;
       highScore = saving.highScore;
       shield = saving.shield;
       doubleCoins = saving.doubleCoins;
       slow = saving.slow;
       shipLevel = saving.shipLevel;       
        ship1 = saving.ship1;
        ship2 = saving.ship2;
        ship3 = saving.ship3;
        DailyRewardedVideo = saving.DailyRewardedVideo;
        expireDate = saving.expireDate;
        date = saving.date;
        ready = saving.ready;
        once = saving.once;

        
   }
}
