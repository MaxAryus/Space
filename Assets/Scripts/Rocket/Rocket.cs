using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;
    public bool freigabe;



    private Player playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(0, speed * 1 * Time.fixedDeltaTime, 0);
        selfDetanation();
    }

    void selfDetanation()
    {
        if(transform.position.y > 15 || playerScript.tot == true)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Astroid")
        {
          
            Destroy(gameObject);
        }
        else if(col.gameObject.tag == "Komet")
        {
            Destroy(gameObject);
        }
    }

    
}
