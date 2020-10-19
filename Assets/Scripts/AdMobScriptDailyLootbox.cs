using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class AdMobScriptDailyLootbox : MonoBehaviour
{
    string APP_ID = "ca-app-pub-2751692428351270~9328219828";
    string adUnitId = "ca-app-pub-2751692428351270/5548380589";
  
    private RewardedAd rewardedBasedVideoLootBox;
    private Saving savingScript;
    public GameObject cheapLootbox;
    private Button buttonScript;
    // Start is called before the first frame update
    void Start()
    {
        buttonScript = cheapLootbox.GetComponent<Button>();
        savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-2751692428351270/5548380589";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            adUnitId = "unexpected_platform";
        #endif

       
        this.rewardedBasedVideoLootBox = new RewardedAd(adUnitId);
        

        // Called when an ad request has successfully loaded.
        this.rewardedBasedVideoLootBox.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedBasedVideoLootBox.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedBasedVideoLootBox.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedBasedVideoLootBox.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedBasedVideoLootBox.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedBasedVideoLootBox.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedBasedVideoLootBox.LoadAd(request);

       
        
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
        this.CreateAndLoadRewardedAdLootBox();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        //test();
        buttonScript.daily = true;
        savingScript.DailyRewardedVideo = true;
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print("HandleRewardedAdRewarded event received for " + amount.ToString() + " " + type);
     
    }

    public void ShowRewardBasedAdLootBox()
    {
        if(savingScript.ready == true)
        {
            if(this.rewardedBasedVideoLootBox.IsLoaded())
            {
           
                this.rewardedBasedVideoLootBox.Show();
            }
            else 
            {
                MonoBehaviour.print("Dude, your ad is not loaded yet.");
            }
        }
      
        
    }
    
    public void CreateAndLoadRewardedAdLootBox()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-2751692428351270/5548380589";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.rewardedBasedVideoLootBox = new RewardedAd(adUnitId);

        this.rewardedBasedVideoLootBox.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardedBasedVideoLootBox.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedBasedVideoLootBox.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedBasedVideoLootBox.LoadAd(request);
    }

    public void test()
    {
        buttonScript.videoLootbox();
        savingScript.DailyRewardedVideo = true;
    }

}
