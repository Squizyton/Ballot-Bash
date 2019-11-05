using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterPlacement : MonoBehaviour
{
    public GameObject poster;
    public GameObject ballot;

    Rigidbody ballotRB;

    public bool inFrontOfWall = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // when p is pressed, a poster appears
        if (Input.GetKeyDown(KeyCode.P) && inFrontOfWall == true)
        {
            Instantiate(poster, new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y / 2), transform.rotation);
            inFrontOfWall = false;
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(ballot, new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x / 2, GameObject.FindGameObjectWithTag("Player").transform.position.y / 2), transform.rotation);
        }

    }
}



