using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text coinText;

    private void Start()
    {
        if (ScoreManager.instance == null)
        {
            Debug.LogError("ScoreManagerÇ™ë∂ç›ÇµÇ‹ÇπÇÒ");
            return;
        }
        coinText.text = $"Coin : {ScoreManager.instance.coin}";
    }

}
