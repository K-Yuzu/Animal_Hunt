
using UnityEngine;


public class ioka_Player : MonoBehaviour
{
    Rigidbody2D rb;
    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

   private void Update()
    {
        //à⁄ìÆèàóù
        if (Input.GetKey(KeyCode.D))
        {
            //âEÇ÷ÇÃà⁄ìÆì¸óÕ
            Vector2 pos = transform.position;
            pos.x += 0.01f;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector2 pos = transform.position;
            pos.x -= 0.01f;
            transform.position = pos;
        }
      
        
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        rb.gravityScale = 0.0f;
        Debug.Log("TriggeríÜ");
        if (other.CompareTag("Ladder"))
        {
            Debug.Log("Ladderê⁄êG");
            
            // è„ÇÈ
            if (Input.GetKey(KeyCode.W))
            {
                Vector3 pos = transform.position;
                pos.y += 0.3f;
                transform.position = pos;
            }

            // â∫ÇÈ
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

