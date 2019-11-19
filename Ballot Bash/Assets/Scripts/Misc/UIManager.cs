using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    public Text timerText;
    public Text scoreText;

    public GameObject scoreManager;
    public int peopleConverted;
    
    public float Timer;

    public bool CountUp, CountDown;

    // Start is called before the first frame update
    void Start()
    {
        if (CountUp)
        {
            Timer = 0;
        }


    }

    // Update is called once per frame
    void Update()
    {
        float t = Timer - Time.time ;


        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;

        peopleConverted = scoreManager.GetComponent<ScoreManager>().ballotPeople + scoreManager.GetComponent<ScoreManager>().posterPeople;
        scoreText.GetComponent<Text>().text = peopleConverted.ToString();
        if(peopleConverted < 10)
        {
            scoreText.GetComponent<Text>().text = "0" + peopleConverted.ToString();
        }

        if (t <= 0)
        {
            t = 0;
            SceneManager.LoadScene(1);
        }

    }
    void TimerCountUp()
    {
        float t = Timer - Time.time;


        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    void TimerCountDown()
    {
        float t = Timer - Time.time;


        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;

    }
}
