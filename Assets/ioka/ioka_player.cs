
using UnityEngine;


public class ioka_Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    bool OnGround = false;
    bool sya = false;
    int jump = 1;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

   private void Update()
    {
        //移動処理
        if (Input.GetKey(KeyCode.D)&&sya==false)
        {
            //右への移動入力
            Vector2 pos = transform.position;
            pos.x += 0.01f;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.A)&&sya==false)
        {
            Vector2 pos = transform.position;
            pos.x -= 0.01f;
            transform.position = pos;
        }
        //しゃがみ
      if(Input.GetKey(KeyCode.LeftControl)&&OnGround==true)
        {
            sya = true;
            Debug.Log("しゃがみ");
            if (Input.GetKey(KeyCode.D))
            {
                //右への移動入力
                Vector2 pos = transform.position;
                pos.x += 0.005f;
                transform.position = pos;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Vector2 pos = transform.position;
                pos.x -= 0.005f;
                transform.position = pos;
            }
        }
      else
        {
            sya = false;
        }
        //ジャンプ
        if (Input.GetKey(KeyCode.Space) && OnGround == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5f);
        }



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("床");
            OnGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        rb.gravityScale = 0.0f;
        //Debug.Log("Trigger中");
        if (other.CompareTag("Ladder"))
        {
            //Debug.Log("Ladder接触");
            
            // 上る
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 pos = transform.position;
                pos.y += 0.3f;
                transform.position = pos;
            }

            // 下る
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 pos = transform.position;
                pos.y -= 0.3f;
                transform.position = pos;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        rb.gravityScale = 1.0f;
    }


}

