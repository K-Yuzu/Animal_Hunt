using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]
    public TMP_Text ResultText;
    void Start()
    {
        int score = PlayerPrefs.GetInt("ResultScore", 0);

        //スコア 1 point / x = コイン
        int coin = score / 10;

        

        StartCoroutine(ResultAnimation(score, coin));
    }

   IEnumerator ResultAnimation(int targetScore,int targetCoin)
    {
        int currentScore = 0;
      
        
        while(currentScore<targetScore)
        {
            currentScore += Mathf.CeilToInt(targetScore / 50f);

            if (currentScore >= targetScore) 
                currentScore = targetScore;

            

            ResultText.text =
            $"スコア : {currentScore}\n";
            
            yield return new WaitForSeconds(0.02f);


           
        }
        yield return new WaitForSeconds(1f);

        int currentCoin = 0;

        while (currentCoin < targetCoin)
        {
            currentCoin += Mathf.CeilToInt(targetCoin / 30f);

            if (currentCoin>targetCoin)
            {
                currentCoin = targetCoin;
            }

            ResultText.text =
            $"スコア:{targetScore}\n" +
          $"獲得コイン : {currentCoin}";

            yield return new WaitForSeconds(0.03f);
        }
       

       

        ResultText.text =
            $"スコア : {targetScore}\n" +
            $"獲得コイン : {targetCoin}";
    }
}
