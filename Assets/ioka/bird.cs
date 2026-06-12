using UnityEngine;

public class bird : MonoBehaviour
{
    [SerializeField] Transform player;
    public float speed = 5f;
    public float moveDistance = 3f;  // âùïúãóó£
    private float previousX;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        sr=GetComponent<SpriteRenderer>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.PingPong(Time.time * speed, moveDistance);
        float currentX = startPos.x + x;

        transform.position = new Vector3(currentX, startPos.y, startPos.z);

        // Å©Ç±Ç±Ç™èdóv
        if (currentX > previousX)
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        else
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);

        previousX = currentX;
    }

    void move()
    {

    }
}
