using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LootBoxContent : MonoBehaviour
{
    private Button buttonScript;
    public TextMeshProUGUI lootBox;
    public string content;
    void Start()
    {
        buttonScript = GameObject.Find("LootboxC").GetComponent<Button>();
        content = buttonScript.content;
        lootBox.text = content;
        StartCoroutine(waitSec());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator waitSec()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
