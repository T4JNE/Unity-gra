using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody rb;
    public Transform player;
    public float MoveSpeed = 10f;
    public float Health = 50f;
    public float Damage = 10f;
    public bool IsAwake = true;
    public float AwakeDistance = 10f;
    public float MaxChaseDistance = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.isKinematic = !IsAwake;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsAwake)
        {
            if (Vector3.Distance(transform.position, player.position) >= MaxChaseDistance && MaxChaseDistance != 0)
            {
                IsAwake = false;
                rb.isKinematic = true;
            }
            else
            {
                Chase();
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) <= AwakeDistance)
            {
                IsAwake = true;
                rb.isKinematic = false;
            }
        }

        if (Health <= 0)
        {
            WaveSpawner.HowMuchSpawned--;
            Player.Points++;
            Destroy(gameObject);
        }
    }

    public void Hit(float damage)
    {
        Health -= damage;
    }

    protected virtual void Chase()
    {
        Vector3 dir = transform.position - player.position;
        dir.Normalize();

        rb.velocity = new Vector3(-dir.x * MoveSpeed, -1f, -dir.z * MoveSpeed);
        //transform.position = Vector3.MoveTowards(transform.position, Target.position, 0.001f);

        //rotation
        float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + 90;
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
