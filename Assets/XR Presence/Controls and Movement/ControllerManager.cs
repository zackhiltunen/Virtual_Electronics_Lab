using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
/// <summary>
/// Disables Controllers not being used
/// DON'T FORGET to set left & right controllers to "left" and "right" tags
/// </summary>
public class ControllerManager : MonoBehaviour
{
    private GameObject leftControllerRig = null;
    private GameObject rightControllerRig = null;
    private List<InputDevice> leftController = null;
    private List<InputDevice> rightController = null;
    private InputDeviceCharacteristics left = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
    private InputDeviceCharacteristics right = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

    private void Awake()
    {
        leftControllerRig = new GameObject();
        rightControllerRig = new GameObject();
        leftController = new List<InputDevice>();
        rightController = new List<InputDevice>();
    }

    private void Start()
    {
        SnapTurnProvider s = gameObject.GetComponent<SnapTurnProvider>();   
    }

    // Update is called once per frame
    private void Update()
    {
        DisableInactiveControllers();
    }

    private void FindActiveControllers()
    {
        
    }

    private void DisableInactiveControllers()
    {
        //initialize all       
        InputDevices.GetDevicesWithCharacteristics(left, leftController);
        InputDevices.GetDevicesWithCharacteristics(right, rightController);
        //Debug.Log(leftControllerObject.name + " Count: " + leftController.Count);
      
        //check left controller
        if (leftController.Count == 0 && leftControllerRig.activeSelf)
            leftControllerRig.SetActive(false);
        if (leftController.Count > 0 && !leftControllerRig.activeSelf)
            leftControllerRig.SetActive(true);

        //check right controller
        if (rightController.Count == 0 && rightControllerRig.activeSelf)
            rightControllerRig.SetActive(false);
        if (rightController.Count > 0 && !rightControllerRig.activeSelf)
            rightControllerRig.SetActive(true);
    }
}
