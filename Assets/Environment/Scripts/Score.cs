using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using XR_Presence.HUD;

namespace cs4910.Scoreboards
{
    public class Score : MonoBehaviour
    {
        public Timer timer;
        public KeypadAnswer button;
        public TextMeshProUGUI scoreboard;
        public CircuitLogic circuit;
        public double attempts = 0;
        double correctCircuits;
        double total_score;
        public double new_score;

        public bool finalScore = false;
        public TextMeshProUGUI answerText;

        public void Start()
        {
            correctCircuits = 0;
            total_score = 100;
            scoreboard.text = "100";
            answerText.text = " ";
        }

        public void Update()
        {
            if(button.buttonPressed > attempts && !finalScore)
            {
                total_score = calculateScore(button, timer, circuit.isComplete);
                scoreboard.text = total_score.ToString();
                attempts++;
            }

        }

        public double calculateScore(KeypadAnswer buttonClicks, Timer time, bool completeCircuit)
        {
            double exp; 
            double retries;
 
            int timeSlot;

            new_score = 0;
            exp = 1.01;
            timeSlot = 0;

            if(completeCircuit)
            {
                if(buttonClicks.result == 5)
                {
                    correctCircuits = correctCircuits + 1;
                    finalScore = true;
                    answerText.text = "Correct";
                    scoreboard.color = Color.green;
                }

                else if(buttonClicks.result < 7 && buttonClicks.result > 3)
                {
                    correctCircuits = correctCircuits + 0.65;
                    answerText.text = "Close Answer";
                    scoreboard.color = Color.yellow;
                }
                else
                {
                    answerText.text = "Incorrect";
                    scoreboard.color = Color.red; 
                }
            }

            else
            {
                correctCircuits = 0;
                answerText.text = "Complete the Circuit";
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
