using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject PlantText;
    private bool isPlayerNearby = false;
    private int point = 10;

    //インベントリ用
    public string ItemDrop;
    public int Amout = 1;

    private void Start()
    {
        
        Debug.Log("test");
        PlantText.SetActive(false);
    }

    private void Update()
    {
        //右クリックを感知
        if (isPlayerNearby&&Input.GetMouseButtonDown(1))
        {
            Debug.Log("右クリック検知");
            Plants();
        }
    }

    void Plants()
    {
        inventory.Instance.addItem(ItemDrop, Amout);
        //テキストとオブジェクトの削除
        //確認用
        Debug.Log("採取した");

        ScoreManager.instance.AddScore(point);

        PlantText.SetActive(false);

        Destroy(gameObject);
       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //プレーヤーの接近を感知
        Debug.Log("Hi!"+other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("eeee");
            isPlayerNearby = true;
            PlantText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //プレイヤーがいない場合、テキストを出さない
        if(other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            PlantText.SetActive(false);
        }
    }
}
