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

    void Start()
    {
        currentHp = MobHP;

        hpSlider.maxValue = MobHP;
        hpSlider.value = currentHp;
    }

    //矢のコライダー判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Attack"))
        {
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

        Debug.Log($"残りHP:{currentHp} 与えたダメージ:{damage}");
        
        if (currentHp <= 0)
        {
            float overDamage=Mathf.Abs(currentHp);

            int finalScore=scoreValue-Mathf.RoundToInt(overDamage);

            //マイナスにならないように
            finalScore=Mathf.Max(0, finalScore);

            ScoreManager.instance.AddScore(finalScore);

            Die();
        }
    }

    //死亡処理
    void Die()
    {

        hpSlider.gameObject.SetActive(false);
        Destroy(gameObject, 0.1f);
    }
}
