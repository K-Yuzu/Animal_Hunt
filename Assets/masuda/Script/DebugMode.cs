using UnityEngine;

public class DebugMode : MonoBehaviour
{
    [SerializeField] private int addCoinAmount = 10;
    [SerializeField] private int addScoreAmount = 10;

    private void Update()
    {
        //Qでコイン追加
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(ScoreManager.instance !=null)
            {
                ScoreManager.instance.AddCoin(addCoinAmount);
                Debug.Log($"コイン +{addCoinAmount}");
            }
        }

        //Eでコイン追加
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(addScoreAmount);
                Debug.Log($"スコア +{addScoreAmount}");
            }
        }

    }

}
