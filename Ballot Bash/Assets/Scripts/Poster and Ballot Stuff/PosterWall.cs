using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterWall : MonoBehaviour

{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            player.GetComponent<PosterPlacement>().inFrontOfWall = true;
        }

    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PosterPlacement>().inFrontOfWall = false;
        }

    }
}
