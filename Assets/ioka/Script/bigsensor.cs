using UnityEngine;

public class bigsensor : MonoBehaviour
{
    public bool playerDetected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
        }
        else if (other.CompareTag("Attack"))
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
        }

        else if (other.CompareTag("Attack"))
        {
            playerDetected = false;
        }
    }

}
