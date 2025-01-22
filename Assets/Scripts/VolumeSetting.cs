using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    // ����� �ͼ��� ������ ������ �����̴����� �־��ش�.
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider bgmSlider;
    


    private void Start()
    {
        // �ʱ� ���� ���¸� �ݿ����ִ� �޼���
        SetInitialSlider();
    }

    private void SetInitialSlider()
    {
        float bgmVolume;

        
        audioMixer.GetFloat("BGM", out bgmVolume);
        

        
        bgmSlider.value = Mathf.Pow(10, bgmVolume / 20);
        
    }

    
    public void SetMasterVolume(float sliderValue)
    {
        // ��� �ι��ϴ°� ���� �ѹ�����
        float volume = Mathf.Log10(sliderValue) * 20;

        audioMixer.SetFloat("BGM", volume);
        
    }

    
    public void SetBGMVolume(float sliderValue)
    {
        if (sliderValue <= 0.001)
            audioMixer.SetFloat("BGM", -80);
        else
            audioMixer.SetFloat("BGM", Mathf.Log10(sliderValue) * 20);
    }
}
