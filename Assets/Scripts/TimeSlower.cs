using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TimeSlower : MonoBehaviour
{
    public static TimeSlower Instance;
    private float timeSinceTrigger = 0f;
    [SerializeField] float playerThinkTime = 7f;

    [SerializeField] AnimationCurve timeSlowAnim;
    public float timeSlowSpeed = 5f;
    public bool isPausing = false;

    private void Start()
    {
        Instance = this;
    }
    public void SetIsPausing(bool isPause)
    {
        isPausing = isPause;
    }
    public void NormalizeTime()
    {
        isPausing = false;
    }
    
    void Update()

    {
        if (!isPausing)
        {
            if (Time.timeScale < 1)
            {
                Time.timeScale = Mathf.Clamp(Time.timeScale+Time.unscaledDeltaTime*timeSlowSpeed, 0f, 1f);
            }
            return;
        }

        if (Time.timeScale > 0f)
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale-Time.unscaledDeltaTime*timeSlowSpeed, 0f, 1f);
        }

        if (Time.timeScale == 0f)
        {
            timeSinceTrigger += Time.unscaledDeltaTime;
            if (timeSinceTrigger > playerThinkTime)
            {
                timeSinceTrigger = 0;
                isPausing = false;

            }
        }
        
    }
        
}