using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace cs4910.Scoreboards
{
    public class Timer : MonoBehaviour
    {
        public TextMeshProUGUI timer;
        public float time;
        public float msec, sec, min;
        public Score score1;

        private void Start()
        {
            StartCoroutine("StopWatch");
        }
        IEnumerator StopWatch()
        {
            while (!score1.finalScore)
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
}
