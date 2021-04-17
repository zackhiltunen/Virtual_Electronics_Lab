using Electrical.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace XR_Presence.HUD
{
    public class HUD : MonoBehaviour
    {
        public Text v;
        public Text a;
        public Voltmeter vm;
        public Ammeter am;
        public CircuitLogic cl;

        public void Start()
        {
            v.text = " V";
            a.text = " A";
        }

         public void Update()
         {
            v.text = cl.voltage + " V";
            a.text = cl.current + " A";
         }
    }
}
