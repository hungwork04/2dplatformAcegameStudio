using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float remainY;
    [SerializeField] private float MinX;
    [SerializeField] private float MaxX;
    public Transform Target;
    private void LateUpdate()
    {
        MoveToTarget();
    }
    public void MoveToTarget()
    {

        Vector3 desertPosition = new Vector3(Target.position.x, remainY, -10);
        if(desertPosition.x> MaxX)
        {
            desertPosition.x = MaxX;
        }else if(desertPosition.x< MinX)
        {
            desertPosition.x = MinX;
        }
        Vector3 cameraMove = Vector3.Lerp(transform.position, desertPosition, cameraSpeed);
        transform.position = cameraMove;
    }
}
