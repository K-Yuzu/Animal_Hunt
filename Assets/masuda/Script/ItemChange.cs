using UnityEngine;

public class ItemChange : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform spawnPoint;
    public void ExChange()
    {
       
    }

    public void SpawmCion()
    {
        Instantiate(coinPrefab,spawnPoint.position,Quaternion.identity);
    }
}
