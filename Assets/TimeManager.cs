﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
     //time we want player to start off
     public static float timeLeft = 600f;

     public static Text text;

     // Start is called before the first frame update
     void Start()
    {
          text = GetComponent<Text>();
     }

    // Update is called once per frame
    void Update()
    {
          timeLeft -= Time.deltaTime;
          if (timeLeft < 0)
               timeLeft = 0;
          text.text = "" + Mathf.Round(timeLeft);
    }
}
