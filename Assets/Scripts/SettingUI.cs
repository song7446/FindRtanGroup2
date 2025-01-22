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
    //Unity�� -80~0�� ������ ���� ������ ������ �����Ѵ�.(-80�� ���Ұ�)
    //�����̴� �ٴ� 0.001~1������ ���� �����ϹǷ� ������ ���� ��ȯ��Ų��.
    //���� �� ������ ���� ���� CurrentValue
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
    //PlayerPrefs�� ����� ���� ��ġ �������
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
