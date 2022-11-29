using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DaytimeManager : MonoBehaviour
{
    const float secondsInDay = 120f;
    public bool pause = false;

    [SerializeField] Color nightLightColor;
    [SerializeField] Color dayLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;

    [SerializeField] UnityEngine.Rendering.Universal.Light2D globalLight;

    float time;

    private void Update()
    {
        if(!pause)
        {
            time += Time.deltaTime;
            float v = nightTimeCurve.Evaluate(time / 120f);
            Color c = Color.Lerp(dayLightColor, nightLightColor, v);
            globalLight.color = c;
            if(time > secondsInDay)
            {
                time = 0;
            }
        }
    }

    public void pauseDaytime (bool val)
    {
        pause = val;
    }
}
