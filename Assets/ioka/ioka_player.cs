using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;

public class ioka_Player : MonoBehaviour
{
   

    private void Start()
    {

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
        else if (Input.GetKey(KeyCode.W))
        {
            Vector2 pos = transform.position;
            pos.y += 0.01f;
            transform.position = pos;
        }
        Ladder();
    }
    void Ladder()
    {
        void OnCollisionEnter(Collision collision)
        {


            if (Input.GetKey(KeyCode.W) && collision.gameObject.CompareTag("Ladder"))
            {
                Vector2 pos = transform.position;
                pos.y += 1f;
                transform.position = pos;
            }
            if (Input.GetKey(KeyCode.S) && collision.gameObject.CompareTag("Ladder"))
            {
                Vector2 pos = transform.position;
                pos.y -= 0.01f;
                transform.position = pos;
            }



        }
    }
    
    

}
