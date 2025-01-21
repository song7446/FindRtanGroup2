using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public Text timeText;
    float time = 0.00f;

    public GameObject endText;

    public int cardCount = 0;
    public int matchCount = 0;

    public Card firstCard;
    public Card secondCard;

    AudioSource audioSource;
    public AudioClip clip;

    //Update()에서 한번만 실행하게끔 - Audio
    bool fastSound = false;
    bool loseSound = false;
    private void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 30.0f)
        {
            Time.timeScale = 0.0f;
            // game over
            UIManager.Instance.OpenResult(false);
            //패배브금 조건
            if (!loseSound)
            {
                //게임 종료시 메인 브금 정지 패배 브금
                AudioManager.instance.LoseSound();
                loseSound = true;
            }
        }
        //배속브금 조건
        else if (time >= 20.0f && !fastSound)
        {
            //브금 빠르게 변경
            AudioManager.instance.FastSound();
            fastSound = true;
        }
        timeText.text = time.ToString("N2");
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // ÆÄ±«
            audioSource.PlayOneShot(clip);
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0.0f;
                UIManager.Instance.OpenResult(true);
                //게임 종료시 메인 브금 정지 승리 브금
                AudioManager.instance.WinSound();
            }
        }
        else
        {
            // ´Ý¾Æ¶ó
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        matchCount++;
        firstCard = null;
        secondCard = null;
    }
}
