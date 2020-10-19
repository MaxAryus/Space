using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using GoogleMobileAds.Api;
using GoogleMobileAds;

public class AdMobScript : MonoBehaviour
{
    string APP_ID = "ca-app-pub-2751692428351270~9328219828";
    string adUnitId = "ca-app-pub-3940256099942544/5224354917";
    
    private RewardedAd rewardBasedVideoCoins;
    private RewardedAd rewardedBasedVideoRevive;
    private RewardedAd rewardedBasedVideoDoubleCoins;
    private RewardedAd rewardedBasedVideoLootBox;
    private Saving savingScript;
    private Player playerScript;
    private Prefabs prefabScript;
    public GameObject cheapLootbox;
    private Button buttonScript;
    private int glücksZahl;
    // Start is called before the first frame update
    void Start()
    {
       
        savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        prefabScript = GameObject.Find("DoubleCoins").GetComponent<Prefabs>();
        #if UNITY_ANDROID
            adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            adUnitId = "unexpected_platform";
        #endif

        this.rewardBasedVideoCoins = new RewardedAd(adUnitId);
        this.rewardedBasedVideoRevive = new RewardedAd(adUnitId);
        this.rewardedBasedVideoDoubleCoins = new RewardedAd(adUnitId);
        this.rewardedBasedVideoLootBox = new RewardedAd(adUnitId);
        

        // Called when an ad request has successfully loaded.
        this.rewardBasedVideoCoins.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardBasedVideoCoins.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardBasedVideoCoins.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardBasedVideoCoins.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardBasedVideoCoins.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardBasedVideoCoins.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request4 = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideoCoins.LoadAd(request4);


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
        buttonScript = cheapLootbox.GetComponent<Button>();
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
        this.CreateAndLoadRewardedAdCoins();
        this.CreateAndLoadRewardedAdRevive();
        this.CreateAndLoadRewardedAdDoubleCoins();
        this.CreateAndLoadRewardedAdLootBox();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
                        + amount.ToString() + " " + type);
        if(glücksZahl == 1)
        {
            savingScript.coins +=1000f;
        }
        else if(glücksZahl == 2)
        {
            playerScript.res = true;
            playerScript.finnisteinspacko = true;
            
        }
        else if(glücksZahl == 3)
        {
            savingScript.coins += playerScript.addCoins;
            prefabScript.zerstören();
            Destroy(gameObject);
        }
        else if(glücksZahl == 4)
        {
            buttonScript.expensiveLootbox();
           savingScript.DailyRewardedVideo = true;
        }
        else
        {
            savingScript.coins += 500;
        }
        
    }

    public void test69()
    {
        buttonScript.expensiveLootbox();
        savingScript.DailyRewardedVideo = true;      
       
    }
    public void test44()
    {
        savingScript.coins += playerScript.addCoins;
        Destroy(gameObject);
    }
    

    public void ShowRewardBasedAdCoins()
    {
       
        if(this.rewardBasedVideoCoins.IsLoaded())
        {
            glücksZahl = 1;
            this.rewardBasedVideoCoins.Show(); 
        }
        else 
        {
            CreateAndLoadRewardedAdCoins();
            MonoBehaviour.print("Dude, your ad is not loaded yet.");
        }
    }

    public void ShowRewardBasedAdRevive()
    {
      
        if(this.rewardedBasedVideoRevive.IsLoaded())
        {
            glücksZahl = 2;
            this.rewardedBasedVideoRevive.Show();
        }
        else 
        {
            MonoBehaviour.print("Dude, your ad is not loaded yet.");
        }
    }


    public void ShowRewardBasedAdDoubleCoins()
    {
      
        if(this.rewardedBasedVideoDoubleCoins.IsLoaded())
        {
            glücksZahl = 3;
            this.rewardedBasedVideoDoubleCoins.Show();
        }
        else 
        {
            MonoBehaviour.print("Dude, your ad is not loaded yet.");
        }
    }


    public void ShowRewardBasedAdLootBox()
    {
      
        if(this.rewardedBasedVideoLootBox.IsLoaded())
        {
            glücksZahl = 4;
            this.rewardedBasedVideoLootBox.Show();
        }
        else 
        {
            MonoBehaviour.print("Dude, your ad is not loaded yet.");
        }
    }
    public void CreateAndLoadRewardedAdCoins()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
            string adUnitId = "unexpected_platform";
        #endif

        this.rewardBasedVideoCoins = new RewardedAd(adUnitId);

        this.rewardBasedVideoCoins.OnAdLoaded += HandleRewardedAdLoaded;
        this.rewardBasedVideoCoins.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardBasedVideoCoins.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardBasedVideoCoins.LoadAd(request);
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
    public void CreateAndLoadRewardedAdDoubleCoins()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
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
    public void CreateAndLoadRewardedAdLootBox()
    {
        #if UNITY_ANDROID
            string adUnitId = "ca-app-pub-3940256099942544/5224354917";
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







    
}
