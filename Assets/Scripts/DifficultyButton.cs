using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DifficultyButton : MonoBehaviour
{
    public GameObject DifficultyUI;

    public GameObject[] BtnArr;

    public void Difficulty()
    {
        Debug.Log(BtnArr.Length);
        DifficultyUI.SetActive(true);
        for (int i = 0; i < BtnArr.Length; i++)
        {    
            BtnArr[i].SetActive(DifficultyManager.instance.stageClear[i]);
        }
    }
}
