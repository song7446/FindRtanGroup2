using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager instance;

    public void Awake()
    {
        // �ν��Ͻ��� ���� ��� 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // ���� ��� �ٽ� �����Ǵ� ���� ����
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
