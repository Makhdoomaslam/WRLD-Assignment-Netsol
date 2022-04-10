using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform helicopter;
    [Range(0.01f, 1.0f)]
    [SerializeField] float SmoothFactor = 0.5f;

    Vector3 cameraOffset;

    void Start()
    {
        cameraOffset = transform.position - helicopter.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 camMovement = helicopter.position - transform.forward * 10f + Vector3.up * 5f;
        //float bias = 0.9f;
        //transform.position = transform.position * bias + camMovement * (1f - bias);

        Vector3 newPos = helicopter.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        transform.LookAt(helicopter.position + transform.forward * 30f);
    }
}
