using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public TMP_Text[] costTexts;

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        Debug.Log(ShopManager.instance.items[0].cost);

        for (int i = 0; i < ShopManager.instance.items.Length; i++)
        {
            costTexts[i].text =
                ShopManager.instance.items[i].cost.ToString();
        }
    }
}