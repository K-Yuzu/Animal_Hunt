using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;

public class PlayerMove : MonoBehaviour
{
    private void Start()
    {
       
    }

    private void Update()
    {
        //ˆÚ“®ˆ—
        if (Input.GetKey(KeyCode.D))
        {
            //‰E‚Ö‚ÌˆÚ“®“ü—Í
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
}
