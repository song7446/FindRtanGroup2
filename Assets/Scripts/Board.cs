using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    public GameObject SpawnPoint;
    public int deck = 20;
    public float CardSlideSpeed;
    public float CardSlideTime;
    public AudioSource audio;
    public AudioClip SlideSound;
    Vector2[] CardTargetPos;
    GameObject[] CardItem;
    [SerializeField]
    int CardCompleteCount;
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = new int[deck];
        // {0,0, 1,1, 2, 2, ...}
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i / 2;
        }
        arr = arr.OrderBy(x => Random.Range(0f, deck / 2.0f)).ToArray();
        boardSetting();
    }

    public void boardSetting()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9 };
        arr = arr.OrderBy(x => Random.Range(0f, 9f)).ToArray();

        CardTargetPos = new Vector2[deck];
        CardItem = new GameObject[deck];

        for (int i = 0; i < deck; i++)
        {
            CardItem[i] = Instantiate(card, SpawnPoint.transform);
            CardItem[i].transform.position = SpawnPoint.transform.position + new Vector3(0, 0, -0.001f * i);
        }
        for (int i = 0; i < CardItem.Length; i++)
        {
            //GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            CardTargetPos[i] = new Vector3(x, y, 0);
            CardItem[i].GetComponent<Card>().Setting(arr[i]);
        }
        GameManager.Instance.cardCount = arr.Length;

        if (deck > 0 && deck <= 24)
        {
            // move Y position
            // 3, 2.3 ,1.6, 0.9, 0.2, x,-1.2
            float replaceY = 3 - ((deck - 1) / 4) * 0.8f;
            transform.position = new Vector3(0, replaceY, 0);
        }

        StartCoroutine(GameStart(CardItem));
    }

    //카드 배치
    IEnumerator GameStart(GameObject[] CardIt)
    {
        for (int i = 0; i < deck; i++)
        {
            audio.PlayOneShot(SlideSound);
            StartCoroutine(SlideMove(CardIt[i], CardTargetPos[i]));
            Debug.Log("!");
            yield return new WaitForSeconds(CardSlideTime);
        }
        yield return null;
    }
    //카드 배치22
    IEnumerator SlideMove(GameObject InputCard,Vector3 TargetPos)
    {
        TargetPos = new Vector3(TargetPos.x, TargetPos.y, InputCard.transform.position.z);
        float Totaldistance = Vector3.Distance(InputCard.transform.position, TargetPos);
        float Cur_distance;
        float Dis_To_Percent;
        //자연스러운 카드 배치를 위해 거리에 따른 속도의 감속을 적용
        while (Vector3.Distance(InputCard.transform.position, TargetPos) > 0.1f)
        {
            Cur_distance = Vector3.Distance(InputCard.transform.position, TargetPos);
            Dis_To_Percent = Mathf.Clamp01(Cur_distance / Totaldistance);
            float Speed = Mathf.Sqrt(1 - Mathf.Pow(Dis_To_Percent - 1, 2));
            InputCard.transform.position = Vector3.MoveTowards(InputCard.transform.position, TargetPos, CardSlideSpeed * Speed * Time.deltaTime);
            yield return null;
        }
        InputCard.transform.position = new Vector3(InputCard.transform.position.x, InputCard.transform.position.y, 0);
        CardCount();
        yield return null;
    }

    //20개 전부 펼쳐지면 게임 시작.
    void CardCount()
    {
        CardCompleteCount++;
        if (CardCompleteCount == 20)
        {
            for (int i = 0; i < deck; i++)
            {
                CardItem[i].GetComponent<Card>().Open_Enable();
            }
            //타이머 시작 함수
            GameManager.Instance.TimerStart();
        }
    }
}
