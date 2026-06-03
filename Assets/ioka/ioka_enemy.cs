using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ioka_enemy : MonoBehaviour
{
    [SerializeField] private minsensor minsensor;
    [SerializeField] private bigsensor bigsensor;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 10f;


    public float speed = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        //target = player.transform;
    }


    private void FixedUpdate()
    {
        if(minsensor.escape_enemy)
        {
            Debug.Log("逃げる");
            escape();
        }
        else if(bigsensor.playerDetected)
        {
            Debug.Log("見つかった");
        }
        else
        {
            Debug.Log("ｍんｌｋんｇヵ");
        }
    }

    void escape()
    {
        if (player == null) return;

        // プレイヤーから敵への方向ベクトル
        Vector2 awayDirection = new Vector2
            (transform.position.x - player.position.x,0f).normalized;
        // 反対方向へ移動
        rb.linearVelocity = awayDirection * moveSpeed;
        sr.flipX = awayDirection.x > 0;
    }
    void Detected()
    {
        Vector2 awayDirection = new Vector2
            (transform.position.x - player.position.x, 0f).normalized;
        sr.flipX = awayDirection.x < 0;
    }
    void Patrol()
    {

    }
}
