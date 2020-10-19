using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class AdMobScriptDoubleCoins : MonoBehaviour
{
    string APP_ID = "ca-app-pub-2751692428351270~9328219828";
    string adUnitId = "ca-app-pub-2751692428351270/6339374610";
    
    private RewardedAd rewardedBasedVideoDoubleCoins;
    private Saving savingScript;
    private Player playerScript;
    private Prefabs prefabScript;
    // Start is called before the first frame update
    void Start()
    {
       
        savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        prefabScript = GameObject.Find("DoubleCoins").GetComponent<Prefabs>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-2751692428351270/6339374610";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            adUnitId = "unexpected_platform";
        #endif

        
        this.rewardedBasedVideoDoubleCoins = new RewardedAd(adUnitId);
        

        // Called when an ad request has successfully loaded.
        this.rewardedBasedVideoDoubleCoins.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedBasedVideoDoubleCoins.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedBasedVideoDoubleCoins.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedBasedVideoDoubleCoins.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedBasedVideoDoubleCoins.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedBasedVideoDoubleCoins.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request2 = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedBasedVideoDoubleCoins.LoadAd(request2);


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
        this.CreateAndLoadRewardedAdDoubleCoins();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
       
       
        savingScript.coins += playerScript.addCoins;
        prefabScript.zerstören2();
        Destroy(gameObject);
       
        
    }

    public void ShowRewardBasedAdDoubleCoins()
    {
      
        if(this.rewardedBasedVideoDoubleCoins.IsLoaded())
        {
           
            this.rewardedBasedVideoDoubleCoins.Show();
        }
        else 
        {
            MonoBehaviour.print("Dude, your ad is not loaded yet.");
        }
    }

    public void CreateAndLoadRewardedAdDoubleCoins()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-2751692428351270/6339374610";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.rewardedBasedVideoDoubleCoins = new RewardedAd(adUnitId);

        this.rewardedBasedVideoDoubleCoins.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedBasedVideoDoubleCoins.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedBasedVideoDoubleCoins.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedBasedVideoDoubleCoins.LoadAd(request);
    }
    
}
