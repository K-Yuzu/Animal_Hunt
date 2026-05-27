using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ArrowGage : MonoBehaviour
{
    private float power;
    public Rigidbody2D rb;
    public Slider slider;

    public float damage=3;
    void Start()
    {
        power = 0;
        slider.value = 0;
    }

    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            if(power<10)
            {
                power += 0.1f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb=GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2( 0, power*2), ForceMode2D.Impulse);
            power = 0;
        }

        Debug.Log("Power");
        slider.value = power * 0.1f;
    }

    
}
