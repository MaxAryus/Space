using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class AstroidMovement : MonoBehaviour
{
    private Player playerScript;
    public float speed;


    public float höhe;
    public float breite;

    private Vector3 spawn1;
    private Vector3 spawn2;

    private Vector3 punkt1;
    private Vector3 punkt2;
    private Vector3 center;
    private Vector3 axis;
    void Start()
    {
        axis.x = 0;
        axis.y = 0;
        axis.z = 1;
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }


    void FixedUpdate()
    {
        transform.Translate(0, speed * -1 * Time.fixedDeltaTime, 0);
        speed = playerScript.astroidSpeed;
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
        else if( playerScript.tot == true)
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
        else if(col.gameObject.tag == "Rocket")
        {
            Destroy(gameObject);
        }
    }

   
}
