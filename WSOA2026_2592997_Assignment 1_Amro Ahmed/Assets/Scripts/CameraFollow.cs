using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector2 offset;

    void LateUpdate()
    {
        Vector3 targetPosition = playerTransform.position + new Vector3(offset.x, offset.y, transform.position.z);
        transform.position = targetPosition;
    }
}