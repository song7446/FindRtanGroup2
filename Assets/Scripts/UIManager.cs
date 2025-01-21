using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject EndUI;
    [SerializeField] private RectTransform ResultUI;
    [SerializeField] private GameObject Answer;
    [SerializeField] private Text result;
    [SerializeField] private Image resultImage;
    [SerializeField] private Text tryTxt;
    [SerializeField] private Text matchTxt;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button mainButton;

    int startCardCount;
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //startCardCount = GameManager.Instance.cardCount;
        startCardCount = 20;
        EndUI.SetActive(false);

        // 버튼에 함수 연결
        retryButton.onClick.AddListener(Restart);
        mainButton.onClick.AddListener(BackToMain);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OpenResult(bool isClear)
    {
        EndUI.SetActive(true);
        // game clear
        if (isClear)
        {
            ResultUI.anchoredPosition = new Vector2(0,-336);
            Answer.SetActive(true);
            result.text = "GAME CLEAR!";
            resultImage.sprite = Resources.Load<Sprite>("face_0");
            // 시도 횟수 추가 할것
            //tryTxt.text = ?;
            matchTxt.text = startCardCount.ToString();
        }
        // game over
        else
        {
            ResultUI.anchoredPosition = new Vector2(0,-700);
            Answer.SetActive(false);
            result.text = "GAME OVER";
            resultImage.sprite = Resources.Load<Sprite>("face_1");
            // 시도 횟수 추가 할것
            //tryTxt.text = ?;
            matchTxt.text = (startCardCount - GameManager.Instance.cardCount).ToString();
        }
    }
    public void Restart()
    {
        // reload now scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("StartScene");
    }

}