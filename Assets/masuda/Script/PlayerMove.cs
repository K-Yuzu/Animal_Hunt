using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;




public class PlayerMove : MonoBehaviour
{
    //移動速度
    public float moveSpeed = 5f;

    //弓
    public GameObject arrowPrefab;
    public Transform firePoint;
   
   
    public float maxPower = 20f;// 最大威力
    public float chargeSpeed = 10f;//たまる速さ
    public float currentPower = 0f;//今の威力
    private float chargeTimer = 0f;

    public float damage;

    public Image fillImage;//ゲージの色


    //UI開いている間動きを止める
    public bool cantMove = true;

    //非戦闘エリア判定
    private bool isInNoShootArea = false;

    //スライダー
    public Slider powerSlider;

    private void Update()
    {
        //UIが開いている間
        if (!cantMove) return;

        Move();

        Aim();

        //左クリックで発射
        if (Input.GetMouseButton(0) && !isInNoShootArea)
        {
            powerSlider.gameObject.SetActive(true);
            chargeTimer += chargeSpeed * Time.deltaTime;
            currentPower=Mathf.PingPong(chargeTimer,maxPower);

        }
        if(Input.GetMouseButtonUp(0)&&!isInNoShootArea)
        {
            Shoot(currentPower + 5,damage);

            chargeTimer = 0f;
            currentPower = 0;//リセット

            powerSlider.gameObject.SetActive(false);
        }

        float ratio = currentPower/maxPower;

        //
        powerSlider.value = ratio;

       if(ratio < 0.3f)
        {
            fillImage.color = Color.green;
            damage = 3f;
        }
       else  if (ratio < 0.7f)
        {
            fillImage.color = Color.cyan;
            damage = 7f;
        }
        else if(ratio<0.99f)
        {
            fillImage.color = Color.yellow;
            damage = 12f;
        }
       else if(ratio<1.0f)
        {
            fillImage.color = Color.red;
            damage = 15f;
        }
    }

    void Move()
    {
        Vector2 pos=transform.position;
        
        //移動処理
        if (Input.GetKey(KeyCode.D))
        {
            //右への移動入力
            pos.x += moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            pos.x -= moveSpeed * Time.deltaTime;
        }
        transform.position = pos;
    }
    void Aim()
    {
        //弓
        //マウスのほうへ
        Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction=mousePos-transform.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        
    }

    void Shoot(float power,float damage)
    {
        //矢を生成
        GameObject arrow = Instantiate(arrowPrefab,firePoint.position,firePoint.rotation);

        //矢に発射方向の力を加える
        Rigidbody2D rb=arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right*power,ForceMode2D.Impulse);

        ShotTest shot =arrow.GetComponent<ShotTest>();

        shot.damage = damage;
    }

    //エリアに入ったとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NoShot"))
        {
            isInNoShootArea = true;
            chargeTimer = 0f;
            currentPower = 0;//リセット

            powerSlider.gameObject.SetActive(false);
        }
    }

    //出たとき
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("NoShot"))
        {
            isInNoShootArea = false;
        }
    }
}
