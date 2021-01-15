using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : LocomotionProvider
{
    public enum InputSource {
        Primary2DAxis = 0,
        Secondary2DAxis
    };
    public InputSource inputSource = InputSource.Primary2DAxis;
    public List<XRController> controllers = null;
    public float speed = 1;
    public float gravityMultiplier = 1;

    private CharacterController characterController = null;
    private GameObject head = null;
    private InputFeatureUsage<Vector2> inputType;
    

    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
        if (inputSource == InputSource.Primary2DAxis) inputType = CommonUsages.primary2DAxis;
        if (inputSource == InputSource.Secondary2DAxis) inputType = CommonUsages.secondary2DAxis;
        else inputType = CommonUsages.primary2DAxis;
    }

    private void Start()
    {
        PositionController();
    }

    private void Update()
    {
        PositionController();
        CheckForInput();
        ApplyGravity();
    }

    private void PositionController()
    {
        //get head in local, playspace ground
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;

        //cut in half, add skin
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        //move capsule in local space (x & z)
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        //now that new center is found, apply to character controller
        characterController.center = newCenter;
    }

    private void CheckForInput()
    {
        foreach (var controller in controllers)
        {
            if (controller.enableInputActions)
                CheckForMovement(controller.inputDevice);
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        if (device.TryGetFeatureValue(inputType, out Vector2 position))
            StartMove(position);
    }

    private void StartMove(Vector2 position)
    {
        //Apply joystick position to head forward vector
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        //Rotate input direction to match head forward direction
        direction = Quaternion.Euler(headRotation) * direction;

        //Apply speed & move
        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier * Time.deltaTime, 0);

        characterController.Move(gravity * Time.deltaTime);
    }
}
