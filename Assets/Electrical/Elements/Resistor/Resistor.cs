using UnityEngine;

namespace Electrical.Elements
{
    public class Resistor : UnityEngine.Component
    {
        public const float resistance = 100f;
        public GameObject resistor;
        public GameObject ammeter;
        public GameObject wire;

        private void Start()
        {
            resistor = gameObject;
        }

        private void Update()
        {

        }
        public bool IsCurrentFlowing()
        {
            if (Node.Nodes(resistor).Count > 1)
            {
                return !(Node.IsParallel(resistor, ammeter) || Node.IsParallel(resistor, wire));
            }
            else
            {
                return false;
            } 
        }

    }
}