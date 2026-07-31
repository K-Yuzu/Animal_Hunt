using UnityEngine;
using UnityEngine.Audio;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    
    public PlayerMove player;
    public Arrow arrow;
    public Arrow cameraOut;

    //Audio
    public AudioSource audioSource;
    public AudioClip kettei;

    [SerializeField] ShopUI shopUI;

    private void Start()
    {
        //player.MoveSpeed = PlayerPrefs.GetFloat("Speed", player.MoveSpeed);
        
        

        arrow.attackBonus = PlayerPrefs.GetFloat("Attack", arrow.attackBonus);
        arrow.zoomStrange=PlayerPrefs.GetFloat("OutLook",arrow.zoomStrange);

        Debug.Log(items[0].cost);
    }

   

    [System.Serializable]
    public class ShopItem
    {
        public string itemName;

        public int cost;        //価格
        public float valueUp = 1f;
        
        public StatType statType;
        public float value;
    }

    public enum StatType
    {
        Speed,
        Attack,
        OutLook
    }

    public ShopItem[] items;

    private void Awake()
    {
        instance = this;

        //保存されたコストを呼び出し
        for (int i = 0; i < items.Length; i++)
        {
            items[i].cost = PlayerPrefs.GetInt(
                items[i].itemName + "_Cost",
                items[i].cost);
        }

    }

    public void BuyItem(int index)
    {
        ShopItem item = items[index];

        if (!ScoreManager.instance.UseCoin(item.cost))
        {
            Debug.Log("スコア不足");
            return;
        }

        ApplyItem(item);

        item.cost += Mathf.RoundToInt(item.cost * item.valueUp);
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(kettei);
        PlayerPrefs.SetInt(item.itemName + "_Cost", item.cost);
        PlayerPrefs.Save();

        shopUI.Refresh();

        Debug.Log(item.itemName + " 購入");
    }

    void ApplyItem(ShopItem item)
    {
        switch (item.statType)
        {
            //移動速度
            case StatType.Speed:
                GameManager.Instance.MoveSpeed += item.value;
                player.MoveSpeed = GameManager.Instance.MoveSpeed;
                break;
            //攻撃力
            case StatType.Attack:
                arrow.attackBonus+= item.value;
                PlayerPrefs.SetFloat (item.itemName, arrow.attackBonus);
                break;
          //カメラ強化
            case StatType.OutLook:
                GameManager.Instance.zoom += item.value;
                arrow.zoomStrange=GameManager.Instance.zoom;
                break;

        }
        //PlayerPrefs.Save();
    }
}