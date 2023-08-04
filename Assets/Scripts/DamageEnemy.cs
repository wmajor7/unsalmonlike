using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public Enemy enemy;
    private int myDamageAmount = 1;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            enemy = other.gameObject.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(myDamageAmount);
            }
        }

        Destroy(this.gameObject);
    }
}
