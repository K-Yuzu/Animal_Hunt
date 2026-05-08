using UnityEngine;

public class ioka_enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTrigger2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vector2 pos = transform.position;
            pos.x += 0.005f;
            transform.position = pos;
        }
    }
}
