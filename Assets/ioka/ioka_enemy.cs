using UnityEngine;

public class ioka_enemy : MonoBehaviour
{
    public Transform player;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player‚ðŠ´’m");
            player = other.transform;
            Vector2 direction = (transform.position - player.position).normalized;

            // ”½‘Î•ûŒü‚ÖˆÚ“®
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
    }
}
