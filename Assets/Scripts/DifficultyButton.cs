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
        DifficultyUI.SetActive(true);
        for (int i = 0; i < BtnArr.Length; i++)
        {
            if (DifficultyManager.instance.stageClear[i])
            {
                BtnArr[i].SetActive(true);
            }
            else
            {
                BtnArr[i].SetActive(false);
            }
        }
    }
}
