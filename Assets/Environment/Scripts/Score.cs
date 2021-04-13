using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace cs4910.Scoreboards
{
    public class Score : MonoBehaviour
    {
        public Timer timer;
        public TextMeshProUGUI score;

        float time;
        public void Start()
        {
            score.text = "100";
        }

        public void Update()
        {
            if (timer.time >= 60)
            {
                score.text = "80";
            }
        }
    }
}
