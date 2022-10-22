using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MoveCubeZad2 : MonoBehaviour
{
    public float speed = 10.0f;
    private float distance;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        distance = rb.position.x;
    }

    void FixedUpdate()
    {
        float distanceDiff = rb.position.x - distance;
        speed = distanceDiff is >= 10 or <= 0 ? speed = -speed : speed;
        Vector3 velocity2 = new Vector3(speed, 0, 0);
        velocity2 = velocity2.normalized * 2 * Time.deltaTime;

        rb.MovePosition(transform.position + velocity2);
    }
}
