using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ioka_enemy : MonoBehaviour
{
    public Transform player;
    public float speed;

    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            
        }

    }
    public void PlayerEnter(AreaSensor.SensorType type, Transform player)
    {
        target = player;

        switch (type)
        {
            case AreaSensor.SensorType.big:
                Debug.Log("遠距離発見 → 追跡開始");
                break;

            case AreaSensor.SensorType.min:
                Debug.Log("近距離警戒");
                break;
        }
    }

    public void PlayerExit(AreaSensor.SensorType type)
    {
        switch (type)
        {
            case AreaSensor.SensorType.big:
                Debug.Log("見失った");
                break;

            case AreaSensor.SensorType.min:
                Debug.Log("近距離範囲外");
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("playerを感知");
            player = other.transform;
            Vector2 direction = (transform.position - player.position).normalized;

            // 反対方向へ移動
            transform.position += (Vector3)(direction * speed * Time.deltaTime);
        }
    }
}
