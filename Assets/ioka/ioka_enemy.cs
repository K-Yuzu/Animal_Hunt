using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ioka_enemy : MonoBehaviour
{
    [SerializeField] private minsensor minsensor;
    [SerializeField] private bigsensor bigsensor;
    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 10f;
    public GameObject dropPrefab;

    public float speed = 3f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    public float timer = 0.0f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject arrow  = GameObject.FindGameObjectWithTag("Attack");
        //target = player.transform;
    }


    private void FixedUpdate()
    {
        if(minsensor.escape_enemy)
        {
            Debug.Log("逃げる");
            escape();
            anim.SetBool("move", true);
            enemyDestroy();
        }
        else if(bigsensor.playerDetected)
        {
            Debug.Log("見つかった");

                anim.SetBool("bikkuri", true);

            
        }
        else
        {
            //Debug.Log("ｍんｌｋんｇヵ");
        }
    }

    private void Update()
    {
       
    }

    private void enemyDestroy()
    {
        //タイマー
        timer += Time.deltaTime;

        if (timer >= 10.0f)
        {
            Destroy(gameObject);
            timer = 0.0f;
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
        //タイマー
        timer += Time.deltaTime;
        if (timer < 3.0f)
        {
            Vector2 walk=new Vector2(transform.position.x-transform.position.x, 0f).normalized;
        }
    }
    void drop()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
    }
}
