using System.Collections;
using System.Collections.Generic;
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

    public float[] timeArr = { 60.0f, 45.0f, 30.0f };
    public float settedTime = 60.0f;

    public void timeSet(int stage)
    {
        settedTime = timeArr[stage];
    }
}
