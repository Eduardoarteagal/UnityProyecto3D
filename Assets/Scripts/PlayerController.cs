using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed=5.0f;
    public float turnSpeed=0.0f;
    public float horizontalInput;
    public float forwardInput;
    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput=Input.GetAxis("Horizontal");
        forwardInput=Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
