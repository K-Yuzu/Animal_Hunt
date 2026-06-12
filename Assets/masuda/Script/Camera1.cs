using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Camera1 : MonoBehaviour
{

    [SerializeField] Transform playerTr;
    [SerializeField] Vector2 cameraMaxPos = new Vector2(5, 5);//âEÇ∆è„ÇÃå¿äEì_
    [SerializeField] Vector2 cameraMinPos = new Vector2(-5, -5);//ç∂Ç∆ÇµÇΩÇÃå¿äEì_
    [SerializeField] Vector3 offset = new Vector3(100f, 100f, 0f); 


    void Update()
    {
        Vector3 targetPos = playerTr.position + offset;

        transform.position = new Vector3(Mathf.Clamp(targetPos.x,cameraMinPos.x,cameraMaxPos.x),
                                           Mathf.Clamp(targetPos.y,cameraMinPos.y,cameraMaxPos.y),
                                           -10f);
    }
}
