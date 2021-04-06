using UnityEngine;

namespace Electrical.Elements
{
    public class Wire : UnityEngine.Component
    {
        public GameObject wire;
        public GameObject ammeter;

        private void Start()
        {
            wire = gameObject;
        }

        public bool IsCurrentFlowing()
        {
            if(Node.Nodes(wire).Count > 1)
            {
                return !Node.IsParallel(wire, ammeter);
            }
            else return false;
        }
    }
}