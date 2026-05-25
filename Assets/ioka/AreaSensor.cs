using UnityEngine;
using static AreaSensor;

public class AreaSensor : MonoBehaviour
{
    ioka_enemy enemy;

    private Vector2 escapeDirection = Vector2.right;

    void Awake()
    {
        enemy = transform.parent.GetComponent<ioka_enemy>();

        if (enemy == null)
        {
            Debug.LogError("êeÇ… ioka_enemy Ç™å©Ç¬Ç©ÇËÇ‹ÇπÇÒ");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (enemy == null) return;

        enemy.SetMoveDirection(escapeDirection);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (enemy == null) return;

        enemy.StopMove();
    }
}
