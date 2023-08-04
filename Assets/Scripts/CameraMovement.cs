using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 5f, -10f);
    public float smoothSpeed = 0.125f;

    private Quaternion initialRotation;

    private void Awake()
    {
        initialRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;


        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.rotation = initialRotation;
    }
}