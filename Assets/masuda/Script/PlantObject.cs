using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject PlantText;
    private bool isPlayerNearby = false;

    private void Start()
    {
        Debug.Log("test");
        PlantText.SetActive(false);
    }

    private void Update()
    {
        if(isPlayerNearby&&Input.GetMouseButtonDown(1))
        {
            Debug.Log("右クリック検知");
            Plants();
        }
    }

    void Plants()
    {
        //確認用
        Debug.Log("採取した");
        PlantText.SetActive(false);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
        if(other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            PlantText.SetActive(false);
        }
    }
}
