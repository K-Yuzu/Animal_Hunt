using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public TMP_Text scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int point)
    {
        score += point;
        scoreText.text = "Score:" + score;
    }
}
