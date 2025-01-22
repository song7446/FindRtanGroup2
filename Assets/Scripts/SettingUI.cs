using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField]
    Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
        LoadAudioSetting();
    }
    //Unity는 -80~0의 범위를 가진 변수로 볼륨을 조절한다.(-80은 음소거)
    //슬라이더 바는 0.001~1사이의 값을 리턴하므로 수식을 통해 변환시킨다.
    //볼륨 값 저장을 위한 변수 CurrentValue
    public void SetLevel(float value)
    {
        float ChangeValue;
        if (value <= 0.001f)
            ChangeValue = -80;
        else
            ChangeValue = Mathf.Log10(value) * 20;
        audioMixer.SetFloat("MasterVolume", ChangeValue);
        SaveAudioSetting(value);
    }
    
    public void SaveAudioSetting(float value)
    {
        PlayerPrefs.SetFloat("MasterVolume", value);
    }
    //PlayerPrefs에 저장된 볼륨 수치 갖고오기
    public void LoadAudioSetting()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            float CurrentValue = PlayerPrefs.GetFloat("MasterVolume");
            Debug.Log(CurrentValue);
            slider.value = Mathf.Clamp(CurrentValue, slider.minValue, slider.maxValue);
            SetLevel(CurrentValue);
        }
    }
}
