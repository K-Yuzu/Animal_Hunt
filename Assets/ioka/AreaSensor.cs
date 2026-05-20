using UnityEngine;
using static AreaSensor;

public class AreaSensor : MonoBehaviour
{
    public enum SensorType
    {
        big,min
    }

    public SensorType sensortype;

    private ioka_enemy ioka_Enemy;

    private void Awake()
    {
        ioka_Enemy=GetComponent<ioka_enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        ioka_Enemy.PlayerEnter(sensortype,other.transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        ioka_Enemy.PlayerExit(sensortype);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
