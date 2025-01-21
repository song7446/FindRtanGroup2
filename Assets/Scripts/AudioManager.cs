using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public void Awake()
    {
        // �ν��Ͻ��� ���� ��� 
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        // ���� ��� �ٽ� �����Ǵ� ���� ����
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioSource audioSource;
    public AudioClip clip;
    // Ŭ�� �߰�
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
