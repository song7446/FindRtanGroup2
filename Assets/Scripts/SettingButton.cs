using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public GameObject SettingCanvas;
    public GameObject StartButton;
    public GameObject DifficultyButton;
    public GameObject ExitButton;


    // Start is called before the first frame update
    public void OpenSetting()
    {
        SettingCanvas.SetActive(true);
        StartButton.SetActive(false);
        DifficultyButton.SetActive(false);
        ExitButton.SetActive(false);
    }

    public void CloseSetting()
    {
        SettingCanvas.SetActive(false);
        StartButton.SetActive(true);
        DifficultyButton.SetActive(true);
        ExitButton.SetActive(true);
    }
}
