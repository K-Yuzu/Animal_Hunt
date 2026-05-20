using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public PlayerMove player;

    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public int cost;
        public StatType statType;
        public float value;
    }

    public enum StatType
    {
        Speed,
        Attack
    }

    public ShopItem[] items;

    private void Awake()
    {
        instance = this;
    }

    public void BuyItem(int index)
    {
        ShopItem item = items[index];

        if (!ScoreManager.instance.UseScore(item.cost))
        {
            Debug.Log("スコア不足");
            return;
        }

        ApplyItem(item);

        Debug.Log(item.itemName + " 購入");
    }

    void ApplyItem(ShopItem item)
    {
        switch (item.statType)
        {
            case StatType.Speed:
                player.moveSpeed += item.value;
                break;

            case StatType.Attack:
                player.launchForce += item.value;
                break;
        }
    }
}