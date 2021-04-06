using UnityEngine;
using UnityEngine.UI;

namespace Electrical.Elements
{
    public class Voltage : MonoBehaviour
    {
        Text v;
        public Voltmeter voltmeter;
        void Start()
        {
            v = GetComponent<Text>();
        }
        void Update()
        {
            v.text = voltmeter.Voltage().ToString() + " V";
        }
    }
}
