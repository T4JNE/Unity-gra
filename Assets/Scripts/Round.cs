using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{
    private float Damage;
    void OnCollisionEnter(Collision other)
    {
        Enemy target = other.gameObject.GetComponent<Enemy>();

        if(target!=null)
        {
            target.Hit(Damage);
        }

        Destroy(gameObject); // Deletes the round
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy target = other.gameObject.GetComponent<Enemy>();

        if (target != null)
        {
            target.Hit(Damage);
        }

        //Destroy(gameObject); // Deletes the round
    }

    public void SetDamage(float damage)
    {
        Damage = damage;
    }
}
