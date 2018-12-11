using System.Collections;
using System.Collections.Generic;
using TMPro;
using Vuforia;
using UnityEngine;

public class TimerScript : MonoBehaviour {

    public TextMeshProUGUI timerText;
    private float startTime;
    private float maximumTime = 20.0f;
    private bool finnished = false;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {


        if (finnished)
            return;


        float t = maximumTime - (Time.time - startTime);

        if(t == 5){
            timerText.color = Color.red;

        }else if(t == maximumTime)
        {
            finnished = true;
        }else{

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");


            timerText.text = minutes + " : " + seconds;
        }

	}


    public void Finnish(){

        timerText.color = Color.grey;
    }
}
