using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    public int shipNumber;
    private Player playerscript;
    public Sprite Falkon;
    public Sprite Enterprise;
    public Sprite SpaceShuttle;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        playerscript = GameObject.Find("Player").GetComponent<Player>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(shipNumber == 1)
        {
            spriteRenderer.sprite = SpaceShuttle;
        }
        else if(shipNumber == 2)
        {
            spriteRenderer.sprite = Enterprise;
        }
        else if(shipNumber == 3)
        {
            spriteRenderer.sprite = Falkon;
        }
        else
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
       


        if(playerscript.tot == true)
        {
            spriteRenderer.enabled = false;
        }
        else if( playerscript.tot == false)
        {
            spriteRenderer.enabled = true;
        }

         if(playerscript.anzeigeRevive == true)
        {
            spriteRenderer.enabled = true;
        }
        
    }
}
