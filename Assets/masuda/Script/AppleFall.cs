using UnityEngine;

public class AppleFall : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private int scoreValue = 100;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();

        //ìñÇΩÇÈÇ‹Ç≈ê√é~
        rb.bodyType=RigidbodyType2D.Static;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Attack"))
        {
            //ñÓÇ™ìñÇΩÇÈÇ∆óéâ∫
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            //ÉXÉRÉA
            ScoreManager.instance.AddScore(scoreValue);

            //è¡Ç∑
            Destroy(gameObject);
        }

    }
}
