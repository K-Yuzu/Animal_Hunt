using UnityEngine;

public class Getitem : MonoBehaviour
{

    public float Destroyspeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject,Destroyspeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
