using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public void Awake()
    {
        // 인스턴스가 없을 경우 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // 있을 경우 다시 생성되는 것을 방지
        else
        {
            Destroy(gameObject);
        }
    }

    public float[] timeArr = { 60.0f, 45.0f, 30.0f, 60.0f };
    public float settedTime = 60.0f;
    public int settedStage = 0;

    public bool[] stageClear = { true, false, false, false };

    public void timeSet(int stage)
    {
        settedStage = stage;
        settedTime = timeArr[stage];
    }

    public void stageOpen()
    {
        settedStage += 1;
        settedTime = timeArr[settedStage];
        stageClear[settedStage] = true;
    }
}
