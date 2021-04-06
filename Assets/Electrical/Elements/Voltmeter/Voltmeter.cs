using System.Collections.Generic;
using UnityEngine;

namespace Electrical.Elements
{
    public class Voltmeter : global::Component
    {
        public VoltageSupply voltageSupply;
        public GameObject voltmeter;
        public List<GameObject> nodes = new List<GameObject>();
        public GameObject resistor;
        public GameObject posProbe;
        public GameObject negProbe;

        private void Start()
        {
            voltmeter = gameObject;
        }

        private void Update()
        {
            nodes = Node.Nodes(voltmeter);
        }

        public float Voltage()
        {
            var direction = 1;

            if(voltageSupply.IsCurrentClockwise()) direction = 1;
            else direction = -1;

            if(nodes.Count > 1 && voltageSupply.IsCurrentFlowing())
            {
                if(Node.IsParallel(resistor, voltmeter))
                    return VoltageSupply.voltage * direction;
                if(Node.IsParallel(voltmeter, posProbe, negProbe))
                    return VoltageSupply.voltage * direction;
                else return 0;
            }
            else return 0;
        }

    }
}