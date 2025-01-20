using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator animator;

    public SpriteRenderer frontImage;

    AudioSource audioSource;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.Instance.secondCard != null) return;

        audioSource.PlayOneShot(clip);

        animator.SetBool("IsOpen", true);
        front.SetActive(true);
        back.SetActive(false);

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

    public void DestoryCard()
    {
        Invoke("DestoryCardInvoke", 0.5f);
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
        front.SetActive(false);
        back.SetActive(true);
    }
}
