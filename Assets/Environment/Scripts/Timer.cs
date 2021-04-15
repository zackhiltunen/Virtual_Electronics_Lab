using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timer;
    public float time;
    public float msec, sec, min;
    
    private void Start()
    {
        StartCoroutine("StopWatch");
    }
    IEnumerator StopWatch()
    {
        while(true)
        {
            time += Time.deltaTime;
            msec = (int)((time - (int)time) * 100);
            sec = (int)(time % 60);
            min = (int)(time / 60 % 60);

            timer.text = string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
            yield return null;
        }
    }
}
