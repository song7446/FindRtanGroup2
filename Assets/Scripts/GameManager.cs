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
    public Text tryText;
    float time = 60.00f;
    float fastTime = 60.00f;

    public GameObject endText;

    public GameObject TryCount;

    public int cardCount = 0;
    public int matchCount = 0;

    public Card firstCard;
    public Card secondCard;

    AudioSource audioSource;
    public AudioClip clip;
    public AudioClip failClip;

    //Update()에서 한번만 실행하게끔 - Audio
    bool fastSound = false;
    bool loseSound = false;
    [SerializeField]
    bool StopTimer;
    [SerializeField] private Color[] backColors;
    [SerializeField] SpriteRenderer BackGround;
    private void Start()
    {
        StopTimer = true;
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();

        time = DifficultyManager.instance.settedTime;
        fastTime = time / 3.0f;
        //BackGround
        BackGround.color = backColors[DifficultyManager.instance.settedStage];
    }

    private void Update()
    {
        if (StopTimer != true)
            time -= Time.deltaTime;
        if (time <= 0.0f)
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
        else if (time <= fastTime && !fastSound)
        {
            //브금 빠르게 변경
            AudioManager.instance.FastSound();
            fastSound = true;

            // trigger Animation
            timeText.GetComponent<Animator>().SetTrigger("Fast");
        }
        timeText.text = time.ToString("N2");
    }

    public void TimerStart()
    {
        StopTimer = false;
    }

    public void TimerStop()
    {
        StopTimer = true;
    }
    public void GameExit()
    {
        Application.Quit();
    }

    public void Matched()
    {
        matchCount++;
        if (firstCard.idx == secondCard.idx)
        {
            // success
            audioSource.PlayOneShot(clip);
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;
            if (DifficultyManager.instance.settedStage == 3)
                time += 3.0f;

            if (cardCount == 0)
            {
                if (DifficultyManager.instance.settedStage == 3)
                {
                    Board board = GameObject.Find("Board").GetComponent<Board>();
                    board.Invoke("boardSetting", 0.7f);
                }
                else
                {
                    Time.timeScale = 0.0f;
                    UIManager.Instance.OpenResult(true);
                    //게임 종료시 메인 브금 정지 승리 브금
                    AudioManager.instance.WinSound();
                }
            }
        }
        else
        {
            // fail
            audioSource.PlayOneShot(failClip);
            firstCard.CloseCard();
            secondCard.CloseCard();
        }
        
        tryText.text = matchCount.ToString();
        firstCard = null;
        secondCard = null;
    }
}
