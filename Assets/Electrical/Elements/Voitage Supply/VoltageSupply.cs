using System.Collections.Generic;
using UnityEngine;

namespace Electrical.Elements
{
    public class VoltageSupply : Component
    {
        public GameObject posProbe;
        public GameObject negProbe;
        public List<GameObject> posNode = new List<GameObject>();
        public List<GameObject> negNode = new List<GameObject>();
        public Resistor resistor;
        public Wire wire;
        public Ammeter ammeter;
        public const float voltage = 12f;
        private void Update()
        {
            posNode = Node.Nodes(posProbe);
            negNode = Node.Nodes(negProbe);
            //Debug.Log("Current flow: " + IsCurrentFlowing() + "\nresistor: " + resistor.IsCurrentFlowing() + nwire: " + wire.IsCurrentFlowing() + \nammeter: " + ammeter.IsCurrentFlowing());
        }

        private bool IsCurrentFlowSupply()
        {
            if (posNode.Count > 0 && negNode.Count > 0)
            {
               return !(Node.IsParallel(resistor.gameObject, posProbe, negProbe) || Node.IsParallel(wire.gameObject, posProbe, negProbe) || Node.IsParallel(ammeter.gameObject, posProbe, negProbe) || string.Equals(posNode[0].name, negNode[0].name));
            }
            else return false;
        }

        public bool IsCurrentFlowing()
        {
            return resistor.IsCurrentFlowing() && wire.IsCurrentFlowing() && IsCurrentFlowSupply() && ammeter.IsCurrentFlowing();
        }
        
         //will return false if no current is flowing
         public bool IsCurrentClockwise()
         {
             if (posNode.Count > 0 && negNode.Count > 0)
             {
                var posNum = Node.NodeNumber(posNode[0]);
                var negNum = Node.NodeNumber(negNode[0]);
                return posNum > negNum && posNum != 0 || posNum == 0 && negNum == 3;
             }
             else return false;
         }
    }
}