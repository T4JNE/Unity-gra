using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    protected override void Chase()
    {
        Vector3 dir = transform.position - player.position;
        dir.Normalize();
        transform.position = Vector3.MoveTowards(transform.position, (player.position + dir), MoveSpeed/100);
        //rotation
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
