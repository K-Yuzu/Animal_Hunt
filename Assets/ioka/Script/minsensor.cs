using UnityEngine;

public class minsensor : MonoBehaviour
{

    public float timer = 0.0f;
    public bool escape_enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            escape_enemy = true;
        }
        else if(other.CompareTag("Attack"))
        {
            
            escape_enemy = true;
        }
    }
        
}
