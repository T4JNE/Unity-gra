using UnityEngine;

public class Target : MonoBehaviour
{
    public float Health = 100f;

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    /// 'Hits' the target for a certain amount of damage
    public void Hit(float damage)
    {
        Health -= damage;
    }
}