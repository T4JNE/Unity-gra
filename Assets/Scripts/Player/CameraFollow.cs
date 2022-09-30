using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Target;
    [SerializeField] private float Smooth = 0.2f;
    [SerializeField] private Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = Target.position + Offset;
        Vector3 smoothedPositon = Vector3.Lerp(transform.position, desiredPosition, Smooth);
        transform.position = smoothedPositon;

        //transform.LookAt(Target);
    }
}
