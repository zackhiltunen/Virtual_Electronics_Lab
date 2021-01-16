using UnityEngine;

namespace Objectives.Scripts
{
    public class Objective : MonoBehaviour
    {
        protected string description = "";
        public string Description
        {
            get { return description;}
            protected set { description = value; }
        }

        [SerializeField]   
        protected bool complete = false;
        public bool Complete => complete;
    }
}