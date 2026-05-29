using UnityEngine;
using UnityEngine.UI;

public class Mob_HP : MonoBehaviour
{
    public float MobHP = 10;

    //追加
    public float currentHp;

    //HPバー
    public Slider hpSlider;

    void Start()
    {
        currentHp = MobHP;

        hpSlider.maxValue = MobHP;
        hpSlider.value = currentHp;
    }

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
                currentHp -= shotTest.damage;
                hpSlider.value = currentHp;
                Debug.Log("残りHPは" + currentHp+"：ダメージは"+shotTest.damage);
            }
        }
    }

    void Mob_delete()
    {
        if (currentHp <= 0)
        {
            Destroy(gameObject,0.1f);
           hpSlider.gameObject.SetActive(false);
        }
    }
}
