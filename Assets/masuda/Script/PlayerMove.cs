using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;




public class PlayerMove : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    bool OnGround = false;
    bool sya = false;
    bool isLadder = false;
    int jump = 1;
    public float DefGravity = 10f;
    public float MoveSpeed = 5f;
    public float jumpspeed = 7f;
    private float MoveX = 0.0f;
    private float MoveY = 0.0f;

    public static PlayerMove Instance;

    //UI開いている間動きを止める
    public bool cantMove = false;
    private void Start()
    {
       // PlayerPrefs.DeleteAll();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        MoveSpeed = GameManager.Instance.MoveSpeed;
    }

    private void Update()
    {
        //移動処理
        if (Input.GetKey(KeyCode.D) && sya == false)
        {
            //右への移動入力
            MoveX = MoveSpeed;
        }
        else if (Input.GetKey(KeyCode.A) && sya == false)
        {
            MoveX = -MoveSpeed;
        }
        else
        {
            MoveX = 0f;
        }
        //しゃがみ
        if (Input.GetKey(KeyCode.LeftControl) && OnGround == true)
        {
            sya = true;
            Debug.Log("しゃがみ");
            if (Input.GetKey(KeyCode.D))
            {
                //右への移動入力
                MoveX = MoveSpeed / 2;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                MoveX = -MoveSpeed / 2;
            }
        }
        else
        {
            sya = false;
        }
        //ジャンプ
        if (Input.GetKey(KeyCode.Space) && OnGround == true && isLadder == false)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpspeed);
        }


        rb.linearVelocity = new Vector2(MoveX, rb.linearVelocity.y);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
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

        //Debug.Log("Trigger中");
        if (other.CompareTag("Ladder"))
        {
            isLadder = true;
           rb.gravityScale = 0.0f;
            //Debug.Log("Ladder接触");

            // 上る
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 pos = transform.position;
                pos.y += 0.1f;
                transform.position = pos;
            }

            // 下る
            if (Input.GetKey(KeyCode.S))
            {
                Vector3 pos = transform.position;
                pos.y -= 0.1f;
                transform.position = pos;
            }
            else
            {
                Vector3 pos = transform.position;
                pos.x += 0.0f;
                transform.position = pos;

            }


        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            MoveX = 0;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.0f);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            rb.gravityScale = DefGravity;

        }
        isLadder = false;
    }
}
