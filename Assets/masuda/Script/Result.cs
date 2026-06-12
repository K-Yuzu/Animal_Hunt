using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField]
    public TMP_Text ResultText;
    void Start()
    {
        int score = PlayerPrefs.GetInt("ResultScore", 0);

        //スコア 1 point / x = コイン
        int coin = score;

        ResultText.text =
            $"スコア : {score}\n" +
            $"獲得コイン : {coin}";
    }

   
    void Update()
    {
        
    }
}
