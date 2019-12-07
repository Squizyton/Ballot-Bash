using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallotBehaviour : MonoBehaviour
{

    public GameObject scoreManager;
    public GameObject health;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score");
        health = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag.Equals("Voter"))
        {
           col.GetComponent<Animator>().SetBool("hurray", true);
          
            scoreManager.GetComponent<ScoreManager>().ballotPeople++;
            health.GetComponent<HealthScript>().health++;
            col.gameObject.GetComponent<Conversation>().DisplayPlayerSentence();
            col.gameObject.GetComponent<Conversation>().gotBallot = true;

            Destroy(gameObject);
        }

        if(col.gameObject.tag.Equals("BallotDestroyer"))
        {
            Destroy(gameObject);
        }

    }
}


