using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ioka_enemy : MonoBehaviour
{
    public float speed = 3f;

    private Rigidbody2D rb;

    private Transform target;

    private Vector2 moveDir;
    private bool isMoving;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
    }

    private void FixedUpdate()
    {

        if (isMoving)
        {
            Vector2 moveDir = (transform.position - target.position).normalized;

            rb.linearVelocity = moveDir * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDir = dir.normalized;
        isMoving = true;
    }

    public void StopMove()
    {
        isMoving = false;
    }
}
