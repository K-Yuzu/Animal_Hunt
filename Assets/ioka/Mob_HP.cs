using UnityEngine;

public class Mob_HP : MonoBehaviour
{
    public float MobHP = 10;
    float damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //ArrowGage arrowgage = GameObject.Find("Arrow").GetComponent<ArrowGage>();
        GameObject arrowobj = GameObject.FindWithTag("Attack");

        if(arrowobj != null )
        {
            ArrowGage arrowgage = arrowobj.GetComponent<ArrowGage>();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Attack"))
        {
            MobHP -= damage;
            Debug.Log("Žc‚èHP‚Í"+MobHP);
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
