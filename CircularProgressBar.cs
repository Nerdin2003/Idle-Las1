using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour
{
    private bool isActive = false;

    private float indicatorTimer; 
    private float maxIndicatorTimer;

    private Image radialProgressBar;

    private void Awake()
    {
        radialProgressBar = GetComponent<Image>();
    }

    private void Update()
    {
        if(isActive)
        {
            indicatorTimer -= Time.deltaTime;
            radialProgressBar.fillAmount = (indicatorTimer / maxIndicatorTimer);

            if (indicatorTimer <= 0)
            {
                StopCountdown();
            }
        }
    }

    public void ActiveCountdown(float countdownTime)
    {
        isActive = true; 
        maxIndicatorTimer = countdownTime;
        indicatorTimer = maxIndicatorTimer; //індикатор повний на початку
    }

    public void StopCountdown()
    {
        isActive = false;
    }
}
