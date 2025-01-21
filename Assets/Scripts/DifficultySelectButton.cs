using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySelectButton : MonoBehaviour
{
    public int stage;

    public void SettingStage()
    {
        DifficultyManager.instance.timeSet(stage);
    }
}
