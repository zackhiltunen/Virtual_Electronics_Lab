using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class PauseMenu : MonoBehaviour
{
    //UI GameObjects
    public GameObject mainPauseMenu;
    public GameObject objectivesMenu;
    public GameObject HUD;

    private List<InputDevice> controllers = null;
    private bool gameIsPaused = false;
    private bool subMenuIsOpen = false;  //Only really used for pause button functionality
    private bool buttonLastPressed = false;

    private void Start(){
        controllers = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, controllers);
        mainPauseMenu = gameObject;
        objectivesMenu = gameObject;
    }

    private void Awake()
    {
        
    }

    private void Update()
    {
<<<<<<< HEAD
=======
        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Controller, controllers);
>>>>>>> workflow-zack
        CheckPause(controllers);
    }

    //Checks for menu button input then pauses or resumes game
    private void CheckPause(List<InputDevice> devices)
    {        
        foreach (var device in devices)
        {
            if (device.TryGetFeatureValue(CommonUsages.menuButton, out bool pressed) && pressed)
            {
                if (pressed != buttonLastPressed)
                {
                    Debug.Log("Menu Button is pressed!");
                    if (gameIsPaused) Resume();
                    else Pause();
                }
                buttonLastPressed = true;
            }
            else buttonLastPressed = false;
        }
       
    }

    //pause the game and activate pause menu
    public void Pause()
    {
        mainPauseMenu.SetActive(true);
        objectivesMenu.SetActive(false);
        HUD.SetActive(false);
        gameIsPaused = true;
        subMenuIsOpen = false;
    }

    //resume the game and disable pause menu
    public void Resume()
    {
        mainPauseMenu.SetActive(false);
        HUD.SetActive(true);
        gameIsPaused = false;        
    }

    //reload scene 1 (level 1)
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    //load scene 0 (main menu scene)
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    //Activate circuit diagram ui and disable pause menu
    public void ObjectivesMenu()
    {
        mainPauseMenu.SetActive(false);
        objectivesMenu.SetActive(true);
        subMenuIsOpen = true;
    }
}
