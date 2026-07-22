using TMPro;
using UnityEngine;

public class inventoryUI : MonoBehaviour
{
    public TMP_Text boarText;
    public TMP_Text birdText;
    public TMP_Text appleText;
    public TMP_Text mushroomText;
    public TMP_Text yagiText;


    // Update is called once per frame
    void Update()
    {
        boarText.text = "イノシシ："+inventory.Instance.boar;
        birdText.text = "鳥："      +inventory.Instance.bird;
        appleText.text="りんご："   +inventory.Instance.apple;
        mushroomText.text="きのこ："+inventory.Instance.mushroom;
        yagiText.text="やぎ :"+ inventory.Instance.yagi;
    }
}
