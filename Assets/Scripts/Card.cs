using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    bool CanOpen;
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator animator;

    public SpriteRenderer frontImage;
    public SpriteRenderer BackImage;
    public Text text;

    AudioSource audioSource;
    public AudioClip clip;

    ParticleSystem Particle;

    // Start is called before the first frame update
    void Start()
    {
        CanOpen = false;
        audioSource = GetComponent<AudioSource>();
        Particle = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"Im{idx}");
        if (number >= 10 && number < 20)
        {
            int rtan = number % 10;
            frontImage.sprite = Resources.Load<Sprite>($"rant{rtan}");
        }
    }

    public void OpenCard()
    {
        if (CanOpen != false)
        {
            CanOpen = false;
            if (GameManager.Instance.secondCard != null) return;

            audioSource.PlayOneShot(clip);

            animator.SetBool("IsOpen", true);

            // firstCard가 비었다면
            if (GameManager.Instance.firstCard == null)
            {
                // firstCard에 내 정보를 넘겨준다.
                GameManager.Instance.firstCard = this;
            }
            else
            {
                // firstCard가 비어있지 않다면
                // secondCard에 내 정보를 넘겨준다
                GameManager.Instance.secondCard = this;
                GameManager.Instance.Matched();
            }
        }
    }

    public void InvisibleCard()
    {
        frontImage.enabled = false;
        BackImage.enabled = false;
        text.enabled = false;
    }
    public void DestoryCard()
    {
        CanOpen = false;
        Invoke("ParticlePlay", 0.3f);
        Invoke("DestoryCardInvoke", 0.8f);
    }

    void ParticlePlay()
    {
        Particle.Play();
    }
    void DestoryCardInvoke()
    {
        Destroy(gameObject);
    }
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 0.5f);
    }

    public void CloseCardInvoke()
    {
        animator.SetBool("IsOpen", false);
        CanOpen = true;
    }

    public void Open_Enable()
    {
        CanOpen = true;
    }

    public void Open_Disable()
    {
        CanOpen = false;
    }
}
