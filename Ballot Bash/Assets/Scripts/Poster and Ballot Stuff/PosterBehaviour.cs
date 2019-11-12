using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterBehaviour : MonoBehaviour
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
        if (col.gameObject.tag.Equals("NonVoter"))
        {
            //convert the non voter to a voter
            // nothing is here yet

            scoreManager.GetComponent<ScoreManager>().posterPeople++;

            //counts number of people converted to voters
            Destroy(gameObject);
        }

    }
}
