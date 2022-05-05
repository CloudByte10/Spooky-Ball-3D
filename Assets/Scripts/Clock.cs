using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    //private Image textBack;
    private Text textClock;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
         //textBack = GetComponent<Image>();
         textClock = GetComponentInChildren<Text>();

        // if (Application.platform != RuntimePlatform.Android)
        // {
        //     textBack.gameObject.SetActive(false);
        //     textClock.gameObject.SetActive(false);
        // }

        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        string time = DateTime.Today.ToString("mm:ss");

        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        textClock.text = minutes + ":" + seconds;

    }
}
