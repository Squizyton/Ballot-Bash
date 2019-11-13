using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

   public int posterPeople = 0;
   public int ballotPeople = 0;

    public int maxPeople = 13;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ballotPeople + posterPeople == maxPeople)
        {
            SceneManager.LoadScene(2);
        }
    }
}
