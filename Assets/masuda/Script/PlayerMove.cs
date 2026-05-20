using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering;


public class PlayerMove : MonoBehaviour
{
    //弓
    public GameObject arrowPrefab;
    public Transform firePoint;
    public float launchForce = 15f;//力の強さ

    //UI開いている間動きを止める
    public bool cantMove = true;

    //非戦闘エリア判定
    private bool isInNoShootArea = false;

    private void Start()
    {
     
    }

    private void Update()
    {
        //UIが開いている間
        if (!cantMove)return;

        //移動処理
        if (Input.GetKey(KeyCode.D))
        {
            //右への移動入力
            Vector2 pos = transform.position;
            pos.x += 0.01f;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Vector2 pos = transform.position;
            pos.x -= 0.01f;
            transform.position = pos;
        }

        //弓
        //マウスのほうへ
        Vector3 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction=mousePos-transform.position;
        float angle=Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //左クリックで発射
        if (Input.GetMouseButtonDown(0)&&!isInNoShootArea)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //矢を生成
        GameObject arrow = Instantiate(arrowPrefab,firePoint.position,firePoint.rotation);

        //矢に発射方向の力を加える
        Rigidbody2D rb=arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right*launchForce,ForceMode2D.Impulse);
    }

    //エリアに入ったとき
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("NoShot"))
        {
            isInNoShootArea = true;
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
