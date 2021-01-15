using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hands : MonoBehaviour
{
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;

    private InputDevice targetDevice;
    private GameObject spawnedHandModel;

    private void Start()
    {
        TryInitialize();
    }

    private void Update()
    {
        if (!targetDevice.isValid) TryInitialize();
    }

    private void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevices(devices);

        if (devices.Count > 0) targetDevice = devices[0];

        spawnedHandModel = Instantiate(handModelPrefab, transform);
    }
}
