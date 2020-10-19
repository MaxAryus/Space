using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class DateTimeStructure : MonoBehaviour
{
    // Start is called before the first frame update
    private Saving savingScript;
    public GameObject videoIcon;
    public Sprite LBIconActive;
    public Sprite LBIconPassive;
    private Image SR;
    public TextMeshProUGUI Available;
    void Start()
    {
        savingScript = GameObject.Find("Saver").GetComponent<Saving>();
        savingScript.date = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
        //savingScript.expireDate = int.Parse(DateTime.Now.AddDays(1).ToString("yyyyMMdd"));
        SR = GameObject.Find("DailyLootbox").GetComponent<Image>();
        Available = GameObject.Find("Available").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(savingScript.DailyRewardedVideo == false)
        {
            SR.sprite = LBIconActive;
            Available.enabled = false;
            savingScript.ready = true;
        }
        else 
        {
            SR.sprite = LBIconPassive;
            Available.enabled = true;
            savingScript.ready = false;
        }
        if(savingScript.date >= savingScript.expireDate && savingScript.DailyRewardedVideo == true)
        {
            savingScript.DailyRewardedVideo = false;
            savingScript.expireDate = int.Parse(DateTime.Now.AddDays(1).ToString("yyyyMMdd"));
        }
    }
}
