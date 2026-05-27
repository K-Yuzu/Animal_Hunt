using UnityEngine;

public class Mob_HP : MonoBehaviour
{
    public float MobHP = 10;
    
    // Update is called once per frame
    void Update()
    {
        Mob_delete();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Attack"))
        {
            ShotTest shotTest = collision.gameObject.GetComponent<ShotTest>();

            if (shotTest != null)
            {
                MobHP -= shotTest.damage;
                Debug.Log("残りHPは" + MobHP+"：ダメージは"+shotTest.damage);
            }
        }
    }

    void Mob_delete()
    {
        if (MobHP <= 0)
        {
            Destroy(gameObject,0.1f);
        }
    }
}
