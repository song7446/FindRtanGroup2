using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DifficultyButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Difficulty()
    {
        SceneManager.LoadScene("DifficultyScene");
    }
}
