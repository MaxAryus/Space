using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewHighScore : MonoBehaviour
{
    private Player playerScript;
    private Spawn spawnScript;
    public TextMeshProUGUI newHighScore;
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        spawnScript = GameObject.Find("Spawn").GetComponent<Spawn>();
        float roundScore = Mathf.Round(playerScript.score);
        newHighScore.text = "New HighScore: " + roundScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnScript.dead == true)
        {
            Destroy(gameObject);
        }
    }
}
