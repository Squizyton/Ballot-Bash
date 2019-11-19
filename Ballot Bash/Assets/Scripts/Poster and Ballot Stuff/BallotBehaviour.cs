using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallotBehaviour : MonoBehaviour
{

    public GameObject scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score");
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
            Destroy(gameObject);
        }

        if(col.gameObject.tag.Equals("BallotDestroyer"))
        {
            Destroy(gameObject);
        }

    }
}


