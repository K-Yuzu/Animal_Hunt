using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShotTest : MonoBehaviour
{
    private Rigidbody2D rb;
    public float lifeTime = 5f;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);
    }

    void Update()
    {
        //ï˙ï®ê¸
        if (rb.linearVelocity!=Vector2.zero)
        {
            float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
