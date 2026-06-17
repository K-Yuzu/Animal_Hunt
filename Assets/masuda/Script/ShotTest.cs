using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShotTest : MonoBehaviour
{
    private Rigidbody2D rb;
    public float lifeTime = 5f;

    public float damage;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);
    }

    void FixedUpdate()
    {
        //ï˙ï®ê¸
        if (rb.linearVelocity!=Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void Update()
    {
        
    }

    void Delete_obj()
    {
        Destroy(gameObject,0.01f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Delete_obj();
        }
        if (collision.gameObject.CompareTag("Mob"))
        {
            Delete_obj();
        }
        if (collision.gameObject.CompareTag("Plant"))
        {
            Delete_obj();
        }
    }
}
