using System;
using UnityEngine;
using UnityEngine.UI;
namespace Electrical.Elements
{
    public class Current : MonoBehaviour
    {
        Text a;
        public Ammeter ammeter;

        void Start()
        {
            a = GetComponent<Text>();
        }

        void Update()
        {
            a.text = ammeter.Current() + " A";
        }
    }
}
