using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


//This script is for the "you have been detected" timer


public class Timer : MonoBehaviour {

    public Text timerText;
    private float startTime;

	// Use this for initialization
	void Start () {
        startTime = 10; //at which time we want to start the timer
    }
	
	// Update is called once per frame
	void Update () {
        //if else if seen goes here
        if (startTime - Time.time >= 0) // replace with if (seen)
        {
            float t = startTime - Time.time;

            string seconds = t.ToString("f2");

            timerText.text = seconds;
        }

        else if (startTime - Time.time <= 0)
        {
            timerText.text = "";
        }
    }
}
