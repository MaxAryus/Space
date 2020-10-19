using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
   public float coins;
   public float highScore;

   public PlayerData (Player player)
   {
       coins = player.coins;
       highScore = player.highScore;
   }
}
