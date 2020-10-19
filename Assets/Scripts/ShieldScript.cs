using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    private Transform Player;
    public Vector3 hallo;
    private Player playerScript;
    SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").GetComponent<Transform>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        sp = GetComponent<SpriteRenderer>();
        transform.parent = Player.transform;
        hallo.x = 0;
        hallo.y  = 0;
        hallo.z = 2;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(playerScript.shieldDestroy == true)
       {
           sp.enabled = false;
        }
        else
        {
            sp.enabled = true;
        }
        if(playerScript.shieldDestroy2 == true)
        {
            playerScript.shieldDestroy2 = false;
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Astroid")
        {
          
         Destroy(col.gameObject);
            
        }
        if(col.gameObject.tag == "Komet")
        {
            Destroy(col.gameObject);
           
        }
       
    }
}
