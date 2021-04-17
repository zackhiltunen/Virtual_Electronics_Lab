using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace XR_Presence.HUD
{
    public class CircuitLogic : MonoBehaviour
    {
        XRSocketInteractor Snap1;
        XRSocketInteractor Snap2;
        XRSocketInteractor Snap3;
        XRSocketInteractor Snap4;
        XRSocketInteractor Snap5;
        XRSocketInteractor SnapVolt1;
        XRSocketInteractor SnapVolt2;
        XRSocketInteractor SnapVolt3;
        XRSocketInteractor SnapVolt4;
        XRSocketInteractor SnapVolt5;

        List<XRSocketInteractor> Snaps = new List<XRSocketInteractor>();
        List<XRSocketInteractor> SnapVolts = new List<XRSocketInteractor>();

        bool isComplete;
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
