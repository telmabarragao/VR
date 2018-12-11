using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Vuforia;
using UnityEngine;

public class TimerScript : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    private float maximumTime = 20.0f;
    private bool finnished = false;
    private float t;


    // Use this for initialization
    void Start()
    {
        startTime = Time.time;
        Debug.Log("comecei");
        finnished = false;
        timerText.color = Color.white;

}

    // Update is called once per frame
    void Update()
    {

        if (finnished)
            return;


        t = maximumTime - (Time.time - startTime);

        if (t <= 5)
        {
            if (t < 0.07)
            {
                Debug.Log("É PARA ACABAR");
                Finnish();
            }else{

                timerText.color = Color.red;
                string minutes = ((int)t / 60).ToString();
                string seconds = (t % 60).ToString("f2");


                timerText.text = minutes + " : " + seconds;
            }
        }
        else
        {

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");


            timerText.text = minutes + " : " + seconds;
        }

        Debug.Log("vai em " + t);


    }


    public void Finnish()
    {
        finnished = true;

        timerText.color = Color.grey;
    }

    public bool isFinnish()
    {

        return finnished;
    }

    public float getTime(){
        return t;
    }

    public void restartTimer()
    {
        startTime = Time.time;
        Debug.Log("recomecei");
        finnished = false;
        timerText.color = Color.white;
    }
}
