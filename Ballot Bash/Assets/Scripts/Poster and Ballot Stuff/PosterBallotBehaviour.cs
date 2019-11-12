using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterBallotBehaviour : MonoBehaviour

{
    public int maxConverted = 1;
    public GameObject voter;
    public GameObject nonVoter;

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
        if (col.gameObject.Equals("NonVoter")) 
        {
            //convert the non voter to a voter
            // nothing is here yet

            //counts number of people converted to voters
            Destroy(gameObject);
        }
    }
}
