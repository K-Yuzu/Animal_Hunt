using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public float timeLimit = 60f;
    public TextMeshProUGUI TimerText;
    public GameObject TestPlayer;

    private bool isFinished = false;

    private void Update()
    {
     

        if(timeLimit > 0)
        {
            timeLimit-= Time.deltaTime;

            if (timeLimit < 0)
                timeLimit = 0;
        }

        int minites = Mathf.FloorToInt(timeLimit / 60);
        int seconds = Mathf.FloorToInt(timeLimit % 60);

        TimerText.text = $"{minites:00}:{seconds:00}";

        if(timeLimit <= 0 && !isFinished)
        {
            Debug.Log("タイムアップ");
            isFinished = true;
            TimeUp();
        }
    }
    void TimeUp()
    {
        PlayerPrefs.SetInt("ResultScore", ScoreManager.instance.score);
        PlayerPrefs.Save();

        
        FadeManager.Instance.LoadScene("Result",1.0f);
        //TestPlayer.transform.position = new Vector3(0f, 0f, 0f);
    }

}
