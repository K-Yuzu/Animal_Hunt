using UnityEngine;

public class PauseManuUI : MonoBehaviour
{
    [SerializeField] private GameObject pauseManu;

    //ほかのUIが開いているかを管理する
    [SerializeField] private UIManager uiManager;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //ポーズメニューが開いてるなら
            if (pauseManu.activeSelf)
            {
                ClosePauseMenu();
                return ;
            }

            //ほかのUIが開いているなら
            if (uiManager.IsAnyUIOpen)
                return;

            //ポーズメニューを開く
           
            OpenPauseMenu();
        }
    }

    public void OpenPauseMenu()
    {
        pauseManu.SetActive(true);
        UIManager.Instance.UIClosed();
        Time.timeScale = 0f;
    }

    public void ClosePauseMenu()
    {
        pauseManu.SetActive(false);
        UIManager.Instance.UIClosed();
        Time.timeScale = 1.0f;
    }
}
