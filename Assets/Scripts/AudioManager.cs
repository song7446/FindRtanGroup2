using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public void Awake()
    {
        // 인스턴스가 없을 경우 
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        // 있을 경우 다시 생성되는 것을 방지
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audioSource;
    public AudioClip clip;
    // 클립 추가
    public AudioClip fastClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        NormalSound();
    }

    public void NormalSound()
    {
        audioSource.clip = this.clip;
        audioSource.pitch = 1.0f;
        audioSource.Play();
    }
    public void FastSound()
    {
        audioSource.clip = this.fastClip;
        audioSource.pitch = 1.3f;
        audioSource.Play();
    }
    public void WinSound()
    {
        audioSource.clip = this.winClip;
        audioSource.pitch = 1.0f;
        audioSource.Play();
    }
    public void LoseSound()
    {
        audioSource.clip = this.loseClip;
        audioSource.pitch = 1.0f;
        audioSource.Play();
    }

}
