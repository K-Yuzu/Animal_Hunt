using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    //スコア
    public int score = 0;

    //コイン
    public int coin = 0;

    //スコアテキスト
    [SerializeField]
    public TMP_Text scoreText;

    [SerializeField]
    private TMP_Text coinText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            //コインのプレイヤーデータを取得
            coin = PlayerPrefs.GetInt("Coin", 0);
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

    public void AddCoin(int amount)
    {
        coin += amount;

        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.Save();

        UpdateUI();
    }

    public bool UseCoin(int amount)
    {
        if(coin<amount)
        {
            return false;
        }

  
        coin -= amount;
        
        PlayerPrefs.SetInt("Coin", coin)
;
        PlayerPrefs.Save();

        UpdateUI();



        return true;
    }

    private void UpdateUI()
    {

        if (scoreText != null)
        {
            scoreText.text = $"Score : {score}";
        }

        if(coinText!=null)
        {
            coinText.text = $"Coin : {coin}";
        }
    }

    public void SetUI(TMP_Text score,TMP_Text coin)
    {
        scoreText = score;
        coinText = coin;

        UpdateUI();
    }
}
