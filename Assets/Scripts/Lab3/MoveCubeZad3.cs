using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MoveCubeZad3 : MonoBehaviour
{
    public float speed = 10.0f;
    private float distanceX;
    private float distanceZ;
    private Vector3 velocity;

    private bool rotate = false;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        distanceX = rb.position.x;
        distanceZ = rb.position.z;
        velocity = new Vector3(speed, 0, 0);
    }

    void FixedUpdate()
    {
        float distanceDiffX = rb.position.x - distanceX;
        float distanceDiffZ = rb.position.z - distanceZ;

        if (distanceDiffX >= 10)
        {
            velocity = new Vector3(0,0,speed);
            distanceX = rb.position.x;
            distanceZ = rb.position.z;
            rotate = true;
        }

        if (distanceDiffZ >= 10)
        {
            distanceX = rb.position.x;
            distanceZ = rb.position.z;
            rotate = true;
            velocity = new Vector3(-speed, 0, 0);
        }

        if (distanceDiffX <= -10)
        {
            distanceX = rb.position.x;
            distanceZ = rb.position.z;
            rotate = true;
            velocity = new Vector3(0, 0, -speed);
        }

        if (distanceDiffZ <= -10)
        {
            distanceX = rb.position.x;
            distanceZ = rb.position.z;
            rotate = true;
            velocity = new Vector3(speed, 0, 0);
        }

        velocity = velocity.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + (velocity));
    }

    void Update()
    {
        if (rotate)
        { 
            rb.transform.Rotate(0, -90, 0);
            rotate = false;
        }
    }
}
