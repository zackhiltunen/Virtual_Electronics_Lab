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
        public KeypadAnswer button;
        public TextMeshProUGUI scoreboard;
        public double attempts = 0;
        double correctCircuits;
        double total_score;
        int answer = 3;

        public void Start()
        {
            correctCircuits = 0;
            total_score = 100;
            scoreboard.text = "100";
        }

        public void Update()
        {
            if(button.buttonPressed > attempts)
            {
                total_score = calculateScore(button, timer);
                scoreboard.text = total_score.ToString();
                attempts++;
            }

        }

        public double calculateScore(KeypadAnswer buttonClicks, Timer time)
        {
            double exp; 
            double retries;
            double new_score;
            
            int timeSlot;

            new_score = 0;
            exp = 1.01;
            timeSlot = 0;

            if(buttonClicks.result == 3)
            {
                correctCircuits = correctCircuits + 1;
            }

            else if(buttonClicks.result < 6 || buttonClicks.result > 1)
            {
                correctCircuits = correctCircuits + 0.5;
            }

            retries =  correctCircuits / buttonClicks.buttonPressed;

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

            if(timeSlot == 5 && correctCircuits == buttonClicks.buttonPressed)
            {
                new_score = 100;
            }

            else
            {
                new_score = Math.Round(((1 / (Math.Pow(5, exp)) ) * (timeSlot) * (retries)) * 100, 1);
            }
            
            return new_score;

        }
    }
}
