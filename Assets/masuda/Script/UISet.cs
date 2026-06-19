using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISet : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text coinText;

    private void Start()
    {
        if(ScoreManager.instance!=null)
        {
            ScoreManager.instance.SetUI(scoreText, coinText);
        }
    }
}
