using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject UIText;

    public RectTransform panelRect;

    private bool isPlayerNearby = false;
    //連打防止
    private bool isOpen = false;

    //プレイヤーの動きを止める
    public PlayerMove playerMove;

  

  

    //パネルの初期位置
    private Vector2 hidePos = new Vector2(0, -1000);
    private Vector2 showPos = new Vector2(0, 0);

    //Audio
    public AudioSource audioSource;
    public AudioClip kettei;
    private void Start()
    {

        Debug.Log("test");
        MenuPanel.SetActive(false);
     
        UIText.SetActive(false);
     

        panelRect.anchoredPosition = hidePos;
    }

    public enum UIType
    {
        Main,
        Shop
    }


    private void Update()
    {

        if (!isOpen && isPlayerNearby && Input.GetMouseButtonDown(1))
        {
            Debug.Log("右クリック検知");
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(kettei);

            UIOpen();

        }
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            UIClose();

        }
    }

    public void UIOpen()
    {

        //確認用
        Debug.Log("オープン");
        isOpen = true;

        UIText.SetActive(false);
        MenuPanel.SetActive(true);


        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(kettei);

        //プレイヤーを止める
        playerMove.cantMove = true;

        Time.timeScale = 0f;

        StartCoroutine(SlidePanel(showPos));
    }
    public void UIClose()
    {
        isOpen = false;
        playerMove.cantMove = false;

        StartCoroutine(ClosePanel());
    }

    //UIを動かす処理
    IEnumerator SlidePanel(Vector2 target)
    {
        float duration = 0.3f;
        float time = 0;

        Vector2 start = panelRect.anchoredPosition;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;

            float t = time / duration;

            t = Mathf.SmoothStep(0, 1, t);

            panelRect.anchoredPosition =
                Vector2.Lerp(start, target, time / 0.3f);

            yield return null;
        }

        panelRect.anchoredPosition = target;

    }

    IEnumerator ClosePanel()
    {
        float duration = 0.3f;
        float time = 0;

        Vector2 start = panelRect.anchoredPosition;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;

            float t = time / duration;

            t = Mathf.SmoothStep(0, 1, t);

            panelRect.anchoredPosition =
                Vector2.Lerp(start, hidePos, t);

            yield return null;
        }

        // 完全に下へ
        panelRect.anchoredPosition = hidePos;

        // 非表示
        MenuPanel.SetActive(false);
      

        Time.timeScale = 1f;
    }


   
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hi!" + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("eeee");
            isPlayerNearby = true;
            UIText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            UIText.SetActive(false);
            //MenuPanel.SetActive(false );
        }
    }

    
    public void SceneMove()
    {
        FadeManager.Instance.LoadScene("Map_ioka",1.0f);
    }
}
