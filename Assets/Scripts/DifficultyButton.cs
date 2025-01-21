using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DifficultyButton : MonoBehaviour
{
    public GameObject DifficultyUI;
    public void Difficulty()
    {
        DifficultyUI.SetActive(true);
    }
}
