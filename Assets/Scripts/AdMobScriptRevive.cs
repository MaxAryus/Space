using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class AdMobScriptRevive : MonoBehaviour
{
    string APP_ID = "ca-app-pub-2751692428351270~9328219828";
    string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    
    private RewardedAd rewardedBasedVideoRevive;
    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            adUnitId = "unexpected_platform";
        #endif

        this.rewardedBasedVideoRevive = new RewardedAd(adUnitId);
        
        // Called when an ad request has successfully loaded.
        this.rewardedBasedVideoRevive.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedBasedVideoRevive.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedBasedVideoRevive.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedBasedVideoRevive.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedBasedVideoRevive.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedBasedVideoRevive.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request3 = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedBasedVideoRevive.LoadAd(request3);
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args.Message);
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardedAdClosed event received");
        this.CreateAndLoadRewardedAdRevive();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
       
            playerScript.res = true;
            playerScript.finnisteinspacko = true;
            playerScript.anzeigeRevive = true;
           
        
    }

    public void ShowRewardBasedAdRevive()
    {
      
        if(this.rewardedBasedVideoRevive.IsLoaded())
        {
            this.rewardedBasedVideoRevive.Show();
        }
        else 
        {
            MonoBehaviour.print("Dude, your ad is not loaded yet.");
        }
    }

    public void CreateAndLoadRewardedAdRevive()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.rewardedBasedVideoRevive = new RewardedAd(adUnitId);

        this.rewardedBasedVideoRevive.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedBasedVideoRevive.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedBasedVideoRevive.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedBasedVideoRevive.LoadAd(request);
    }
    public void erscheinen()
    {
        playerScript.anzeigeRevive = true;
    }
   
}
