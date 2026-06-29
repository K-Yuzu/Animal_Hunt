using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;
    
    public PlayerMove player;
    public Arrow arrow;
    public Arrow cameraOut;

    [SerializeField] ShopUI shopUI;

    private void Start()
    {
        player.MoveSpeed = PlayerPrefs.GetFloat("Speed", player.MoveSpeed);
        arrow.attackBonus = PlayerPrefs.GetFloat("Attack", arrow.attackBonus);
        arrow.zoomStrange=PlayerPrefs.GetFloat("OutLook",arrow.zoomStrange);
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

        shopUI.Refresh();

        Debug.Log(item.itemName + " 購入");
    }

    void ApplyItem(ShopItem item)
    {
        switch (item.statType)
        {
            //移動速度
            case StatType.Speed:
                player.MoveSpeed += item.value;
                PlayerPrefs.SetFloat(item.itemName, player.MoveSpeed);
                break;
            //攻撃力
            case StatType.Attack:
                arrow.attackBonus+= item.value;
                PlayerPrefs.SetFloat (item.itemName, arrow.attackBonus);
                break;
          //カメラ強化
            case StatType.OutLook:
               arrow.zoomStrange+= item.value;
                PlayerPrefs.SetFloat(item.itemName , arrow.zoomStrange);
                break;

        }
        PlayerPrefs.Save();
    }
}