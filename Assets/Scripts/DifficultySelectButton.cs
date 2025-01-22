using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultySelectButton : MonoBehaviour
{
    public int stage;

    public void SettingStage()
    {
        DifficultyManager.instance.timeSet(stage);
        SceneManager.LoadScene("MainScene");
    }
}
