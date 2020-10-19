using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class KometMovement2D : MonoBehaviour
{
    private Player playerScript;
    public float speed;
    public float leben;


    public float höhe;
    public float breite;

    private Vector3 spawn1;
    private Vector3 spawn2;

    private Vector3 punkt1;
    private Vector3 punkt2;
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        leben = 2;
    }


    void FixedUpdate()
    {
        transform.Translate(0, speed * -1 * Time.fixedDeltaTime, 0);
        speed = playerScript.kometSpeed;
        selfDetonation();
        punkt1.x = 0f;
        punkt1.y = 0f;

        spawn1 = Camera.main.ScreenToWorldPoint(punkt1);
    }

    void selfDetonation()
    {
        if (transform.position.y <=spawn1.y)
        {
            Destroy(gameObject);
        }

        else if(leben <= 0)
        {
            Destroy(gameObject);
        }
        else if(playerScript.tot == true)
        {
            Destroy(gameObject);
        }

        
    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
          
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Rocket")
        {
            leben--;
        }
    }

   
}
