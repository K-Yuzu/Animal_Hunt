using UnityEngine;

public class NoShotArea : MonoBehaviour
{
    public Arrow arrow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NoShot"))
            {
            arrow.SetNoShootArea(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NoShot"))
        {
            arrow.SetNoShootArea(false);
        }
    }
}
