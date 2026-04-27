using UnityEngine;

public class Plant : MonoBehaviour
{
    public GameObject PlantText;
    private bool isPlayerNearby = false;

    private void Start()
    {
        PlantText.SetActive(false);
    }

    private void Update()
    {
        
    }
}
