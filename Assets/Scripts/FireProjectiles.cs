using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectiles : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform target;
    public float fireRate = 3f;
    public float radius = 2f;

    private float timeSinceLastFire = 0f;

    void Update()
    {
        if (target == null)
        {
            FindClosestEnemy();
            return;
        }

        timeSinceLastFire += Time.deltaTime;

        if (timeSinceLastFire >= fireRate)
        {
            FireProjectile();
            timeSinceLastFire = 0f;
        }
    }

    void FireProjectile()
    {
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        Vector3 closestPointOnCircle = transform.position + (directionToTarget * radius);

        GameObject projectile = Instantiate(projectilePrefab, closestPointOnCircle, Quaternion.identity);

        Vector3 lookRotation = Quaternion.LookRotation(directionToTarget).eulerAngles;
        projectile.transform.rotation = Quaternion.Euler(lookRotation);

        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        if (rb != null)
        {
            float projectileSpeed = 2f;
            rb.velocity = directionToTarget * projectileSpeed;
        }
    }

    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy.transform;
            }
        }

        target = closestEnemy;
    }
}