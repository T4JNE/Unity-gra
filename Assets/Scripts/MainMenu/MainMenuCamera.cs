using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public Transform Cam;
    public Vector3 Offset;
    public float Speed;
    public Transform LookAtObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Cam.transform.position = new Vector3(Mathf.Sin(Time.time * Speed) * Offset.x, Offset.y, Mathf.Cos(Time.time * Speed) * Offset.z);
        Cam.transform.LookAt(LookAtObj);

    }
}
