using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public Text timerText;

    
    private float Timer;


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - Timer;


        string minutes = ((int)t / 60).ToString(); 


    }
}
