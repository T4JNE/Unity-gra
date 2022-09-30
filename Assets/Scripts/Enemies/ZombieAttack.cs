using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Enemy enemy;

    private float Damage;
    void Start()
    {
        Damage = enemy.Damage;
    }

    private void OnTriggerStay(Collider other)
    {
        Player target = other.gameObject.GetComponent<Player>();

        if (target != null)
        {
                target.Hit(Damage);
        }
    }
}
