using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float MoveSpeed = 5f;
    public float zoom = 1.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
