using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterBehaviour : MonoBehaviour
{
    public GameObject scoreManager;
    public GameObject Voter;
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
            Instantiate(Voter, new Vector3(col.gameObject.transform.position.x,col.gameObject.transform.position.y + .4f,GameObject.Find("Bob").transform.position.z), col.transform.rotation);
            col.transform.position = new Vector3(9999999999999999, 99999999999999999, 9999999999999999999);
            scoreManager.GetComponent<ScoreManager>().posterPeople++;

            //counts number of people converted to voters
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

    }
}
