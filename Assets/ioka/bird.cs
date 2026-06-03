using UnityEngine;

public class bird : MonoBehaviour
{
    [SerializeField] Transform player;
    public float speed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void move()
    {
        Vector2 awayDirection = new Vector2
            (transform.position.x - player.position.x, 0f).normalized;
        // ”½‘Î•ûŒü‚ÖˆÚ“®
        //rb.linearVelocity = awayDirection * speed;
       
    }
}
