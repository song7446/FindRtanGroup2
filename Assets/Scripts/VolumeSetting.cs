using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSetting : MonoBehaviour
{
    // 오디오 믹서와 볼륨을 조절할 슬라이더들을 넣어준다.
    public AudioMixer audioMixer;
    public Slider volumeSlider;
    public Slider bgmSlider;
    


    private void Start()
    {
        // 초기 볼륨 상태를 반영해주는 메서드
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
        // 계산 두번하는것 보다 한번으로
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
