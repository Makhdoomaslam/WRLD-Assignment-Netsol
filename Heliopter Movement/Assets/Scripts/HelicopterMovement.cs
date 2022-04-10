using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 90f;

    // Update is called once per frame
    void Update()
    {
       // transform.position += transform.forward * Time.deltaTime * movementSpeed;

        //Vector3 camMovement = transform.position - transform.forward * 10f + Vector3.up * 5f;
        //float bias = 0.9f;
        //Camera.main.transform.position = transform.position * bias + camMovement * (1f - bias);

        //Camera.main.transform.LookAt(transform.position + transform.forward * 30f);

        //movementSpeed -= transform.forward.y * Time.deltaTime * 50f;
        //if (movementSpeed < 50f)
        //    movementSpeed = 50f;
        transform.Rotate(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal"));
    }
}
