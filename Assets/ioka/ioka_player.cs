using UnityEngine;

public class ioka_Player : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    bool OnGround = false;
    bool sya = false;
    bool isLadder = false;
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

   private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("move",true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("move", true);
        }
        else
        {
            anim.SetBool("move", false);
        }
        //ÇµÇ·Ç™Ç›
      if (Input.GetKey(KeyCode.LeftControl) && OnGround == true)
        {

        }
        else
        {

        }
        //ÉWÉÉÉìÉv
        if (Input.GetKey(KeyCode.Space) && OnGround == true&&isLadder==false)
        {

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Ç‰Ç©Ç‰Ç©Ç‰Ç©Ç©Ç©Ç©Ç©Ç©Ç©Ç†Ç©Ç©Ç©Ç©Ç©Ç©");
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
        
        //Debug.Log("TriggeríÜ");
        if (other.CompareTag("Ladder"))
        {
            isLadder= true;
            //Debug.Log("Ladderê⁄êG");
            
            // è„ÇÈ
            if (Input.GetKey(KeyCode.W))
            {
            }

            // â∫ÇÈ
            if (Input.GetKey(KeyCode.S))
            {
            }
            else
            {
            }
        

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ladder"))
        {

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            
        }
        isLadder = false;
    }


}

