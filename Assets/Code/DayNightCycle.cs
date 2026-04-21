using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using NUnit.Framework.Constraints;

public class DayNightCycle : MonoBehaviour
{
    public TextMeshProUGUI timeDisplay;
    public TextMeshProUGUI dayDisplay;
    public Volume ppv; //post Processign volume  

    public float tick;
    public float seconds;
    public int mins;
    public int hours;
    public int days = 1;

    public bool activateLights;
    public GameObject[] lights;
    public SpriteRenderer[] stars;


    void Start()
    {
        ppv = gameObject.GetComponent<Volume>();
        
    }

    void FixedUpdate()
    {
        CalcTime();
        DisplayTime();

    }

    public void CalcTime()
    {
        seconds += Time.fixedDeltaTime * tick;

        if(seconds >= 60)
        {
            seconds = 0;
            mins++;
        }

        if(mins >= 60)
        {
            mins = 0;
            hours++;
        }

        if(hours >= 24)
        {
            hours = 0;
            days++;
        }
        ControlPPV();
    }

    public void ControlPPV()
    {
        if(hours>=21 && hours < 22)
        {
            ppv.weight = (float)mins / 60;
            for (int i =0; i <stars.Length; i++)
            {
                stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, (float)mins/60);
            }
        

            if(activateLights == false)
            {
                if(mins > 45)
                {
                    for(int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(true);
                    }
                    activateLights = true;
                }
            }
        }

        if(hours >= 6 && hours < 7)
        {
            ppv.weight = 1 - (float)mins / 60;
            for(int i = 0; i < stars.Length; i++)
            {
                 stars[i].color = new Color(stars[i].color.r, stars[i].color.g, stars[i].color.b, 1 -(float)mins/60);
            }

            if(activateLights == true)
            {
                if(mins > 45)
                {
                    for(int i = 0; i < lights.Length; i++)
                    {
                        lights[i].SetActive(false);
                    }
                    activateLights = false;
                }
            }
        }
    }

    public void DisplayTime()
    {
        timeDisplay.text = string.Format("{00:00}:{1:00}", hours, mins);
        dayDisplay.text = "Day: "+ days;
    }

}
