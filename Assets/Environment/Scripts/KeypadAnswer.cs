using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace cs4910.Scoreboards
{
    public class KeypadAnswer : MonoBehaviour
    {
        public string input = "";
        public TextMeshProUGUI display;
        public int result;
        public double buttonPressed = 0;
        public Button one;
        public Button two;
        public Button three;
        public Button four;
        public Button five;
        public Button six;
        public Button seven;
        public Button eight;
        public Button nine;
        public Button zero;
        public Button clear;
        public Button submit;
        void Start()
        {
            one.GetComponent<Button>().onClick.AddListener(pressOne);
            two.GetComponent<Button>().onClick.AddListener(pressTwo);
            three.GetComponent<Button>().onClick.AddListener(pressThree);
            four.GetComponent<Button>().onClick.AddListener(pressFour);
            five.GetComponent<Button>().onClick.AddListener(pressFive);
            six.GetComponent<Button>().onClick.AddListener(pressSix);
            seven.GetComponent<Button>().onClick.AddListener(pressSeven);
            eight.GetComponent<Button>().onClick.AddListener(pressEight);
            nine.GetComponent<Button>().onClick.AddListener(pressNine);
            zero.GetComponent<Button>().onClick.AddListener(pressZero);
            clear.GetComponent<Button>().onClick.AddListener(pressClear);
            submit.GetComponent<Button>().onClick.AddListener(pressSubmit);
        }

        void Update()
        {
            if(input.Length < 6)
            {
                display.text = input;
            }
        }
        void pressOne()
        {
            input = input + "1";
        }
        
        void pressTwo()
        {
            input = input + "2";
        }

        void pressThree()
        {
            input = input + "3";
        }

        void pressFour()
        {
            input = input + "4";
        }

        void pressFive()
        {
            input = input + "5";
        }

        void pressSix()
        {
            input = input + "6";
        }

        void pressSeven()
        {
            input = input + "7";
        }

        void pressEight()
        {
            input = input + "8";
        }

        void pressNine()
        {
            input = input + "9";
        }

        void pressZero()
        {
            input = input + "0";
        }

        void pressClear()
        {
            input = "";
        }

        void pressSubmit()
        {
            buttonPressed++;
            result = Int32.Parse(input);
            input = "";
        }
    }
}