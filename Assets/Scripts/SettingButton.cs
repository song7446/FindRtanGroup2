using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingButton : MonoBehaviour
{
    public GameObject SettingCanvas;
    // Start is called before the first frame update
    public void OpenSetting()
    {
        SettingCanvas.SetActive(true);
    }

    public void CloseSetting()
    {
        SettingCanvas.SetActive(false);
    }
}
