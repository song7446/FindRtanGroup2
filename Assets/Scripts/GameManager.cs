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
    float time = 60.00f;

    public GameObject endText;

    public int cardCount = 0;
    public int matchCount = 0;

    public Card firstCard;
    public Card secondCard;

    AudioSource audioSource;
    public AudioClip clip;

    private void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();

        time = DifficultyManager.instance.settedTime;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0.0f)
        {
            Time.timeScale = 0.0f;
            // game over
            UIManager.Instance.OpenResult(false);
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

    public void infinityMatched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);
            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;
            time += 3.0f;
            if (cardCount == 0)
            {
                Board board = GameObject.Find("Board").GetComponent<Board>();
                board.Invoke("boardSetting", 0.7f);
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
