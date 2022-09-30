using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed = 1.0f;
    public Rigidbody rb;
    public Weapon weapon;

    public UnityEvent OnHealthChange;
    public static UnityEvent OnPointsChange;

    [SerializeField] private float _health = 100f;
    public float Health
    {
        get => _health;

        set
        {
            _health = value;
            if (_health > 100)
                _health = 100;

            OnHealthChange?.Invoke();
        }
    }

    [SerializeField] private static float _points = 100f;
    public static float Points
    {
        get => _points;

        set
        {
            _points = value;
            OnPointsChange?.Invoke();
        }
    }

    //public static int Points;

    private Light[] flashlights;

    private float horizontalKey;
    private float verticalKey;

    private float ImmuneTimer;

    // Start is called before the first frame update
    void Start()
    {
        if(OnHealthChange == null)
        {
            OnHealthChange = new UnityEvent();
        }

        if (OnPointsChange == null)
        {
            OnPointsChange = new UnityEvent();
        }

        rb = GetComponent<Rigidbody>();
        flashlights = GetComponentsInChildren<Light>();

        Points = 0;

        if (GameSettings.isNight)
        {
            foreach (var item in flashlights)
            {
                item.enabled = !item.enabled;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenuScript.GamePaused)
            return;

        //Movement
        horizontalKey = Input.GetAxis("Horizontal");
        verticalKey = Input.GetAxis("Vertical");

        //Rotation
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, -dir.x) * Mathf.Rad2Deg + 180;
        transform.rotation = Quaternion.Euler(0, angle, 0);

        //Shootin
        if (Input.GetMouseButton(0))
        {
            weapon.Shoot();
        }

        if (Input.GetKeyDown("r"))
        {
            weapon.Reload();
        }
    }

    private void FixedUpdate()
    {
        //Movement
        Vector3 direction = new Vector3(horizontalKey, -1f, verticalKey);
        rb.velocity = Vector3.ClampMagnitude(direction, 1f) * PlayerSpeed;
    }

    public void Hit(float damage)
    {
        if (ImmuneTimer < Time.time)
        {
            Health -= damage;
            ImmuneTimer = Time.time + 1;

            //Health
            if (Health <= 0)
            {
                Debug.Log("Dead");
            }
        }
    }
}
