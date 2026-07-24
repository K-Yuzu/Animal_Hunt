using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Arrow : MonoBehaviour
{

    //弓
    public GameObject arrowPrefab;
    public Transform firePoint;

    public SpriteRenderer playerSprite;


    public float maxPower = 20f;// 最大威力
    public float chargeSpeed = 10f;//たまる速さ
    public float currentPower = 0f;//今の威力
    private float chargeTimer = 0f;

    public float damage;
    public float attackBonus = 0f;

    public Image fillImage;//ゲージの色
                           //非戦闘エリア判定
    private bool isInNoShootArea = false;

    //スライダー
    public Slider powerSlider;

    //時間
    public float slowTimeScale = 0.05f;
    public float slowSpeed = 6.0f;

    //カメラ
    public Camera mainCamera;

    public float nomalSize = 5f;
    public float zoomSize = 4f;
    public float zoomSpeed = 5f;

    //カメラ視野強化
    public float zoomStrange;

    //UI開いている間動きを止める
    public bool cantMove = true;

    //コライダー
    BoxCollider2D col;

    //Audio
    
    public AudioSource audioSource;
    public AudioClip ArrowCharge;
    public AudioClip ArrowShot;
    private void Start()
    {
        col = GetComponentInParent<BoxCollider2D>();
        attackBonus = PlayerPrefs.GetFloat("Attack", 0f);
        zoomStrange = GameManager.Instance.zoom;
    }

    private void Update()
    {
        //UIが開いている間
        if (!cantMove) return;

        //Move();

        Aim();

        //左クリックで発射
        if (Input.GetMouseButton(0) && !isInNoShootArea)
        {


            powerSlider.gameObject.SetActive(true);
            chargeTimer += chargeSpeed * Time.unscaledDeltaTime;
            currentPower = Mathf.PingPong(chargeTimer, maxPower);

            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(ArrowCharge);


        }
        if (Input.GetMouseButtonUp(0) && !isInNoShootArea)
        {

            Shoot(currentPower + 5);

            chargeTimer = 0f;
            currentPower = 0;//リセット

            powerSlider.gameObject.SetActive(false);

           // if (!audioSource.isPlaying)
                audioSource.PlayOneShot(ArrowShot);
        }

        float ratio = currentPower / maxPower;

        //
        powerSlider.value = ratio;
        float baseDamage;
        if (ratio < 0.3f)
        {
            fillImage.color = Color.green;
            baseDamage = 1f;
        }
        else if (ratio < 0.7f)
        {
            fillImage.color = Color.cyan;
            baseDamage = 3f;
        }
        else if (ratio < 0.95f)
        {
            fillImage.color = Color.yellow;
            baseDamage = 5f;
        }
        else
        {
            fillImage.color = Color.red;
            baseDamage = 10f;
        }
        damage = baseDamage + attackBonus;

        //スローにしてみる処理
        float targetTimeScale =
            (Input.GetMouseButton(0) && !isInNoShootArea)
            ? slowTimeScale
            : 1f;

        Time.timeScale = Mathf.Lerp
            (Time.timeScale,
            targetTimeScale,
            Time.unscaledDeltaTime * slowSpeed);

        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        //カメラズーム
        float targetSize =
            (Input.GetMouseButton(0) && !isInNoShootArea)
            ? zoomSize + zoomStrange
            : nomalSize;

        mainCamera.orthographicSize = Mathf.Lerp
            (mainCamera.orthographicSize,
            targetSize,
            Time.unscaledDeltaTime * zoomSpeed);

  
    }
    void Aim()
    {
        //弓
        //マウスのほうへ
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        
        //弓のみ
        transform.rotation = Quaternion.Euler(0,0,angle);
       

        if (direction.x<0)
        {
            playerSprite.flipX = true;
            col.offset = new Vector2(-0.3f, col.offset.y);
        }
        else
        {
            playerSprite.flipX = false;
            col.offset = new Vector2(0.3f, col.offset.y);
        }
      

    }

    void Shoot(float power)
    {
       

        //矢を生成
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        //矢に発射方向の力を加える
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * power, ForceMode2D.Impulse);

        ShotTest shot = arrow.GetComponent<ShotTest>();

        //
        float ratio = currentPower / maxPower;

        //
        float finalDamage = Mathf.Lerp(1f, 10f, ratio);

        //
        finalDamage = Mathf.Round(finalDamage);

        //
        finalDamage += attackBonus;


        shot.damage = finalDamage;
        Debug.Log("Arrow damage = " + finalDamage);
    }

    public void SetNoShootArea(bool value)
    {
        isInNoShootArea = value;

        if(value)
        {
            chargeTimer = 0f;
            currentPower = 0f;

            powerSlider.gameObject.SetActive(false);
        }
    }
}
