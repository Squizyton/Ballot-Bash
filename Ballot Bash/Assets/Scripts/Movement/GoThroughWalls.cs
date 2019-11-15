using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoThroughWalls : MonoBehaviour
{
    public GameObject player;
   // public GameObject parentPlatform;
    public BoxCollider2D parentCollider;
    public BoxCollider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") == -1)
        {
            //the layer moving platforms cannot collide with
            gameObject.layer = 9;
        }
        else
        {
            gameObject.layer = 0; //default layer
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            var platform = transform.parent;
            Physics2D.IgnoreCollision(playerCollider, parentCollider);
        }
        
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            player.gameObject.layer = 0;

            var platform = transform.parent;
            Physics2D.IgnoreCollision(playerCollider, parentCollider, false);
        }
    }


}
