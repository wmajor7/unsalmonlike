using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyPickups : MonoBehaviour
{
    public float movementSpeed = 2.0f;
    public float movementDistance = 1.0f;

    private Vector3 initialPosition;
    private float direction = 1.0f;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        Vector3 newPosition = transform.position + Vector3.up * movementSpeed * direction * Time.deltaTime;

        if (Vector3.Distance(newPosition, initialPosition) > movementDistance)
        {
            direction *= -1.0f;
        }

        transform.position = newPosition;
    }
}
