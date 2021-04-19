using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace XR_Presence.HUD
{
    public class CircuitLogic : MonoBehaviour
    {
        public XRSocketInteractor Snap1;
        public XRSocketInteractor Snap2;
        public XRSocketInteractor Snap3;
        public XRSocketInteractor Snap4;
        public XRSocketInteractor Snap5;
        public XRSocketInteractor SnapVolt1;
        public XRSocketInteractor SnapVolt2;
        public XRSocketInteractor SnapVolt3;
        public XRSocketInteractor SnapVolt4;
        public XRSocketInteractor SnapVolt5;

        public List<XRSocketInteractor> Snaps = new List<XRSocketInteractor>();
        public List<XRSocketInteractor> SnapVolts = new List<XRSocketInteractor>();

        public bool isComplete;
        int[] resistances = {0,3,10,5,0};
        public double voltage = 0;
        public double current = 0;

        // Start is called before the first frame update
        void Start()
        {   
            Snaps.Add(Snap1);
            Snaps.Add(Snap2);
            Snaps.Add(Snap3);
            Snaps.Add(Snap4);
            Snaps.Add(Snap5);
            
            SnapVolts.Add(SnapVolt1);
            SnapVolts.Add(SnapVolt2);
            SnapVolts.Add(SnapVolt3);
            SnapVolts.Add(SnapVolt4);
            SnapVolts.Add(SnapVolt5);

            isComplete = false;
        }

        // Update is called once per frame
        void Update()
        {
            checkDesign(Snap1, Snap2, Snap3, Snap4, Snap5);
            if (isComplete)
            {
                for(int i = 0; i < 5; i++)
                {
                    // m_ValidTargets is originally a private variable
                    // if the attribute is not found, verify that it is public
                    if(SnapVolts[i].m_ValidTargets.Count > 0){
                        voltage = getVoltage(Snaps[i],SnapVolts[i], i);
                        current = 0.5;
                    }
                }
            }
        }

        void checkDesign(XRSocketInteractor s1, XRSocketInteractor s2, XRSocketInteractor s3, XRSocketInteractor s4, XRSocketInteractor s5)
        {
            if(s1.m_ValidTargets.Count > 0 && s2.m_ValidTargets.Count > 0 && s3.m_ValidTargets.Count > 0 && s4.m_ValidTargets.Count > 0 && s5.m_ValidTargets.Count > 0)
            {
                isComplete = true;
            }
        }

        double getVoltage(XRSocketInteractor snap, XRSocketInteractor snapVolt, int i)
        {
            if(i == 0){
                return 9.0;
            }
            else if(i == 4){
                return 0.0;
            }
            else{
                return 0.5*(resistances[i]);
            }
        }
    }
}
