using UnityEngine;
using UnityEngine.UI;

public class Mob_HP : MonoBehaviour
{
    //最大HP
    public float MobHP = 10;

    //現在のHP
    public float currentHp;

    //スコア
    public int scoreValue;

    //HPバー
    public Slider hpSlider;

    public GameObject dropPrefab;

    //コライダー
    public Collider2D colider;

    //攻撃ヒット回数
    private int Hit_dame = 0;

    //
    private Rigidbody2D rb;

    public string ItemDrop;
    public int Amout = 1;

    //Audio
    public AudioSource audioSource;
    public AudioClip ArrowDamage;
    void Start()
    {
        currentHp = MobHP;

        hpSlider.maxValue = MobHP;
        hpSlider.value = currentHp;

        colider = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    //矢のコライダー判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Attack"))
        {
            //ヒット回数を加算
            Hit_dame++;
            
            ShotTest shotTest = collision.gameObject.GetComponent<ShotTest>();

            if (shotTest != null)
            {
               TakeDamage(shotTest.damage);
            }
        }
    }

    //ダメージ処理
    void TakeDamage(float damage)
    {
        currentHp -= damage;
        hpSlider.value = currentHp;

        if(!audioSource.isPlaying) 
            audioSource.PlayOneShot(ArrowDamage);

        Debug.Log($"残りHP:{currentHp} 与えたダメージ:{damage}");
        
        if (currentHp <= 0)
        {
            float overDamage=Mathf.Abs(currentHp);

            int finalScore=scoreValue-Mathf.RoundToInt(overDamage);
            //マイナスにならないように
            finalScore =Mathf.Max(0, finalScore);
            finalScore /= Hit_dame;
            ScoreManager.instance.AddScore(finalScore);//スコアを加算

            Die();
        }
    }

    //死亡処理
    void Die()
    {
        inventory.Instance.addItem(ItemDrop,Amout);
        drop();
        hpSlider.gameObject.SetActive(false);
        Destroy(gameObject,0.3f);
        colider.enabled=false;

        rb.constraints = RigidbodyConstraints2D.FreezeAll; ;
    }
    void drop()
    {
        Instantiate(dropPrefab, transform.position, Quaternion.identity);
    }
}
