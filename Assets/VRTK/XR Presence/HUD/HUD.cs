using Electrical.Elements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace XR_Presence.HUD
{
    public class HUD : MonoBehaviour
    {
        public GameObject v;
        public GameObject a;
        public TextMeshPro vText;
        public TextMeshPro aText;

        public CircuitLogic cl;

        public void Start()
        {
            vText = v.GetComponent<TextMeshPro>();
            aText = a.GetComponent<TextMeshPro>();

            vText.text += " V";
            aText.text += " A";
        }

         public void Update()
         {
            vText.text = "Voltage: " + cl.voltage + " V  /";
            aText.text = "  Current: " + cl.current + " A";
         }
    }
}
