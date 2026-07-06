using TMPro;
using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    public TMP_Text boarText;
    public TMP_Text birdText;

    // Update is called once per frame
    void Update()
    {
        boarText.text = "イノシシ："+inventory.Instance.boar;
    }
}
