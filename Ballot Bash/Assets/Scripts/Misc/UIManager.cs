using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //timer things
    public Text timerText;
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
        if (CountUp)
        {
            TimerCountUp();
        }
        else if (CountDown)
        {
            TimerCountDown();
        }
    }

   void TimerCountDown()
    {
        
        float t = Timer - Time.time;

        string minutes = ((int)t / 60).ToString();

        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }

    void TimerCountUp()
    {

        float t = Timer + Time.time;

        string minutes = ((int)t / 60).ToString();

        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }
}
