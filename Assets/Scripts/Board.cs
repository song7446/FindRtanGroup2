using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Board : MonoBehaviour
{
    public GameObject card;
    public int deck = 20;
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

        for (int i = 0; i < deck; i++)
        {
            GameObject go = Instantiate(card, this.transform);

            float x = (i % 4) * 1.4f - 2.1f;
            float y = (i / 4) * 1.4f - 3.0f;

            go.transform.position = new Vector2(x, y);
            go.GetComponent<Card>().Setting(arr[i]);
        }

        GameManager.Instance.cardCount = arr.Length;


        if (deck > 0 && deck <= 24)
        {
            // move Y position
            // 3, 2.3 ,1.6, 0.9, 0.2, x,-1.2
            float replaceY = 3 - ((deck - 1) / 4) * 0.8f;
            transform.position = new Vector3(0, replaceY, 0);
        }

    }
}
