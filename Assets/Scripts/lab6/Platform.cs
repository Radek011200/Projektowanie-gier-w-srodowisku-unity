using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    private float downPosition;
    private float upPosition;
    private Transform oldParent;
    public List<Vector3> points;
    private int number = 0;
    private Vector3 target;
    private bool back = false;
    void Start()
    {
        target = points[0];
    }

    void FixedUpdate()
    {
        var step = Mathf.Abs(elevatorSpeed) * Time.deltaTime;
        if (isRunning)
        {
            if (Vector3.Distance(transform.position, target) < 0.001f && !back)
            {
                target = points[number];
                if (points.Count -1 == number)
                    back = true;
                number++;
            }
            else if (Vector3.Distance(transform.position, target) < 0.001f && back)
            {
                number--;
                target = points[number];
                if (number == 0)
                    back = false;
            }
            else
                transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player wszedł na windę.");
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            
            if (transform.position.z >= upPosition)
            {
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= downPosition)
            {
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player zszedł z windy.");
            other.gameObject.transform.parent = oldParent;
        }
    }
}
