using System.Collections;
using UnityEngine;

public class UIPanel : MonoBehaviour
{

    public GameObject MenuPanel;
    public GameObject UIText;

    public RectTransform panelRect;

    private bool isPlayerNearby = false;
    //連打防止
    private bool isOpen = false;

    //プレイヤーの動きを止める
    public PlayerMove playerMove;
    
    //こんにちはテキスト
    public GameObject HelloText;

    //パネルの初期位置
    private Vector2 hidePos = new Vector2(0, -1000);
    private Vector2 showPos = new Vector2(0, 0);

    private void Start()
    {

        Debug.Log("test");
        MenuPanel.SetActive(false);
        UIText.SetActive(false);
        HelloText.SetActive(false);

        panelRect.anchoredPosition = hidePos;
    }

    private void Update()
    {

        if (!isOpen && isPlayerNearby && Input.GetMouseButtonDown(1))
        {
            Debug.Log("右クリック検知");
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
        
        //プレイヤーを止める
        playerMove.cantMove = false;

        Time.timeScale = 0f;

        StartCoroutine(SlidePanel(showPos));
    }
    public void UIClose()
    {
        isOpen = false;
        MenuPanel.SetActive(false);

        //動ける
        playerMove.cantMove = true;

      StartCoroutine(ClosePanel());
    }

    //UIを動かす処理
    IEnumerator SlidePanel(Vector2 target)
    {
        float duration = 0.3f;
        float time = 0;

        Vector2 start=panelRect.anchoredPosition;

        while (time <　duration)
        {
            time += Time.unscaledDeltaTime;

            float t = time / duration;

            t= Mathf.SmoothStep(0,1,t);

            panelRect.anchoredPosition =
                Vector2.Lerp(start,target,time/0.3f);

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


    //こんにちはテキスト処理
    public void SayHello()
    {
        StartCoroutine(ShowHello());
        UIClose();
    }

    IEnumerator ShowHello()
    {
        HelloText.SetActive(true);
        yield return new WaitForSeconds(2f);
        HelloText.SetActive(false) ;
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
}
