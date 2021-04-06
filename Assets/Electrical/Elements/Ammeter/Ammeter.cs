using Electrical.Elements;
using UnityEngine;

namespace Electrical.Elements
{
    public class Ammeter : UnityEngine.Component
    {
        public VoltageSupply voltageSupply;
        public GameObject ammeter;

        private void Start()
        {
            ammeter = gameObject;
        }

        private void Update()
        {

        }

        public bool IsCurrentFlowing()
        {
            return Node.Nodes(ammeter).Count > 1;
        }

        public float Current(){
            if (voltageSupply.IsCurrentFlowing()){
                if (voltageSupply.IsCurrentClockwise())
                    return VoltageSupply.voltage / Resistor.resistance;
                else return -VoltageSupply.voltage / Resistor.resistance;
            }
            else return 0;
        }
    }
}