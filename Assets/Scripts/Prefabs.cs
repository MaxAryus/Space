using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    public GameObject destroyPrefab;
    private Player playerScript;
    public GameObject bild1;
    public GameObject bild2;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.finnisteinspacko == true)
        {
            Destroy(destroyPrefab);
           
        }        
    }
    public void zerstören()
    {
        Destroy(destroyPrefab);
    }
    public void zerstören2()
    {
        Destroy(destroyPrefab);
        Destroy(bild1);
        Destroy(bild2);
    }
   
}
