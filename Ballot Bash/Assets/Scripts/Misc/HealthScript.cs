using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{

    public GameObject fullHealth;
    public GameObject twoHealth;
    public GameObject oneHealth;
    public GameObject noHealth;

    public int health = 3;

    // working on it


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
        if(col.gameObject.tag.Equals("NonVoter"))
        {
            health--;

           if(health == 2)
            {
                fullHealth.SetActive(false);
            }
           else if(health == 1)
            {
                fullHealth.SetActive(false);
                twoHealth.SetActive(false);
            }
           else if(health == 0)
            {
                fullHealth.SetActive(false);
                twoHealth.SetActive(false);
                oneHealth.SetActive(false);
            }


           else if(health < 0)
            {
                SceneManager.LoadScene(1);
            }

        }
    }
}
