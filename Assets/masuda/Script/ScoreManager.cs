using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;

    [SerializeField]
    public TMP_Text scoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void AddScore(int point)
    {
        score += point;
        UpdateUI();
     
    }

    public bool UseScore(int amount)
    {
        if(score<amount)
        {
            return false;
        }

        score -= amount;
        UpdateUI();

        return true;
    }

    private void UpdateUI()
    {
        scoreText.text = "Score:" + score;
    }
}
