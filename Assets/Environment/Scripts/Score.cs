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
        public SubmitCircuit button;
        public TextMeshProUGUI scoreboard;
        double total_score;
        public void Start()
        {
            total_score = 100;
            scoreboard.text = "100";
        }

        public void Update()
        {
            if(button.n > 0)
            {
                total_score = calculateScore(button, timer);
                scoreboard.text = total_score.ToString();
            }

        }

        public double calculateScore(SubmitCircuit buttonClicks, Timer time)
        {
            double exp; 
            double retries;
            double new_score;
            double correctCircuits; 
            int timeSlot;

            new_score = 0;
            correctCircuits = 1;
            exp = 1.01;
            timeSlot = 0;
            retries =  correctCircuits / buttonClicks.n;

            if (time.min < 10)
            {
                if (time.min < 2)
                {
                    timeSlot = 5;
                }

                else if (time.min < 4)
                {
                    timeSlot = 4;
                }

                else if (time.min < 6)
                {
                    timeSlot = 3;
                }

                else
                {
                    timeSlot = 2;
                }
            }
            
            else
            {
                timeSlot = 1;
            }

            new_score = Math.Round(((1 / (Math.Pow(5, exp)) ) * (timeSlot) * (retries)) * 100, 2);
            return new_score;

        }
    }
}
