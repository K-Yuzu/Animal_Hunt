using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Camera : MonoBehaviour
{
    [SerializeField] Transform playerTr;
    [SerializeField] Vector2 cameraMaxPos = new Vector2(5, 5);//âEÇ∆è„ÇÃå¿äEì_
    [SerializeField] Vector2 cameraMinPos = new Vector2(-5, -5);//ç∂Ç∆ÇµÇΩÇÃå¿äEì_
    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(playerTr.position.x,cameraMinPos.x,cameraMaxPos.x),
                                           Mathf.Clamp(playerTr.position.y,cameraMinPos.y,cameraMaxPos.y),
                                           -10f);
    }
}
