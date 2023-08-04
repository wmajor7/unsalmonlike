using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDistance : MonoBehaviour
{
    public Transform playerTransform;
    public float attractionDistance = 10f;
    public float attractionSpeed = 2f;
    public float pickupDistance = 1f;

    private bool isAttracted = false;

    private void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        // Calculate the distance between the player and the object
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= attractionDistance)
        {
            isAttracted = true;
        }
        else
        {
            isAttracted = false;
        }

        if (isAttracted)
        {
            Vector3 directionToPlayer = playerTransform.position - transform.position;

            directionToPlayer.Normalize();

            transform.position += directionToPlayer * attractionSpeed * Time.deltaTime;
        }

        if (distanceToPlayer < pickupDistance)
        {
            print("Add XP to player total");
            Destroy(this.gameObject);
        }
    }

}
