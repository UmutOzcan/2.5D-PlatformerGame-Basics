using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //target kameranın seçtiği nesne olacak
    private Transform target;
    private Vector3 offset;

    public float smoothSpeed = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    // LateUpdate daha smooth bi grafik için kullanılır
    void LateUpdate()
    {
        //transform.position = target.position + offset;
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition , smoothSpeed);
    }
}

