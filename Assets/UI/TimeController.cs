using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true;
    public float gameTime = 0;
    public bool isTimeOver = false;
    public float displayTime = 0;

    float times = 0;

    private void Start()
    {
        if(isCountDown)
        {
            displayTime = gameTime;
        }
    }

    private void Update()
    {
        if(isTimeOver == false)
        {
            times += Time.deltaTime;
            if(isCountDown )
            {
                displayTime = gameTime - times;
                if(displayTime <= 0.01f)
                {
                    displayTime = 0;
                    isTimeOver = true;
                }
            }
            else
            {
                displayTime = times;
                if(displayTime >= gameTime)
                {
                    displayTime = gameTime;
                    isTimeOver = true;
                }
            }
        }
    }
}
