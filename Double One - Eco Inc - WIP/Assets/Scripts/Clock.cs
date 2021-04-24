using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TMPro.TextMeshProUGUI[] UI_TIME_TEXT;
    public TMPro.TextMeshProUGUI[] UI_DATE_TEXT;
    public TimeForm timeForm = TimeForm.hour_24;
    public DateFrom dateForm = DateFrom.YYYY_MM_DD;
    public float secondPerMin = 1;

    private string _time;
    private string _date;

    private bool isAM = false;

    int hour;
    int minute;

    int year;
    int month;
    int day;

    int maxHour = 1;
    int maxMinute = 30;
    int maxDay = 31;
    int maxMonth = 13;

    float timer = 0;

    public enum TimeForm
    {
        hour_24,
        hour_12

    }
    public enum DateFrom
    {
        MM_DD_YYYY,
        DD_MM_YYYY,
        YYYY_MM_DD,
        YYYY_DD_MM
    }

    private void Awake()
    {
        hour = System.DateTime.Now.Hour;
        minute = System.DateTime.Now.Minute;
        day = System.DateTime.Now.Day;
        month = System.DateTime.Now.Month;
        year = System.DateTime.Now.Year;

        if (hour < 12)
        {
            isAM = true;
        }

        setTimeDateString();
    }


    // Update is called once per frame
    void Update()
    {
        if(timer >= secondPerMin)
        {
            minute++;
            if (minute >= maxMinute)
            {
                minute = 0;
                hour++;
                if(hour >= maxHour)
                {
                    hour = 0;
                    day++;
                    if (day >= maxDay)
                    {
                        day = 1;
                        month++;
                        if(month >= maxMonth)
                        {
                            month = 1;
                            year++;
                        }
                    }
                }
            }
            setTimeDateString();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    void setTimeDateString()
    {
        switch(timeForm)
        {
            case TimeForm.hour_12:
                {
                    int h;

                    if(hour >= 13)
                    {
                        h = hour - 12;
                    }
                    else if (hour == 0)
                    {
                        h = 12;
                    }
                    else
                    {
                        h = hour;
                    }
                    _time = h + ":";

                    if (minute <= 9)
                    {
                        _time += "0" + minute;
                    }
                    else
                    {
                        _time += minute;
                    }
                    if (isAM)
                    {
                        _time += " AM";
                    }
                    else
                    {
                        _time += " PM";
                    }

                    break;
                }
            case TimeForm.hour_24:
                {
                    if(hour <= 9 )
                    {
                        _time = "0" + hour + ":";
                    }
                    else
                    {
                        _time = hour + ":";
                    }
                    if(minute <= 9)
                    {
                        _time += "0" + minute;
                    }
                    else
                    {
                        _time += minute;
                    }
                    break;
                }
        }

        switch(dateForm)
        {
            case DateFrom.DD_MM_YYYY:
            {
               _date = day + "/" + month + "/" + year;

                break;
            }
            case DateFrom.MM_DD_YYYY:
            {
                    _date = month + "/" + day + "/" + year;
                    break;
            }
            case DateFrom.YYYY_DD_MM:
            {
                    _date = year + "/" + day + "/" + month;
                    break;
            }
            case DateFrom.YYYY_MM_DD:
            {
                    _date = year + "/" + month + "/" + day;
                    break;
            }
        }

        for(int i = 0; i < UI_TIME_TEXT.Length; i++)
        {
            UI_TIME_TEXT[i].text = _time;
        }
        for(int i = 0; i < UI_DATE_TEXT.Length; i++)
        {
            UI_DATE_TEXT[i].text = _date;
        }
    }

}
