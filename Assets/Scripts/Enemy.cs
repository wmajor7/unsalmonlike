using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 2;

    private int currentHealth;

    public GameObject XP;
    Vector3 dropLocation;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        dropLocation = new Vector3(transform.position.x, 1f, transform.position.z);
        Instantiate(XP, dropLocation, transform.rotation);
        Destroy(this.gameObject);
    }
}
