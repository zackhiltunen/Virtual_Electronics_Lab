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

        private void Awake()
        {
            vm = FindObjectOfType<Voltmeter>();
            am = FindObjectOfType<Ammeter>();
        }

        public void Update()
        {
            v.text = " V";
            a.text = " A";
        }
    }
}
