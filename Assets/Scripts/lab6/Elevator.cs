using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 7f;
    private bool isRunningTargetPosition = true;
    private bool isRunningBasePosition = false;
    private float BasePositonZ;
    private float targetPositonZ;
    private bool isPlayerOnElevate = false;
    private bool upTouchZ = false;
    private bool downTouchZ = false;
    private Transform oldParent;
    void Start()
    {
        targetPositonZ = transform.position.z + distance;
        BasePositonZ = transform.position.z;
    }

    void FixedUpdate()
    {
        
        if (isRunningTargetPosition && transform.position.z >= targetPositonZ)
        {
            upTouchZ = true;
            if (isPlayerOnElevate || (!upTouchZ || !downTouchZ))
            {
                isRunningBasePosition = true;
                isRunningTargetPosition = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else
            {
                isRunning = isPlayerOnElevate;
            }
        }
        else if (isRunningBasePosition && transform.position.z <= BasePositonZ)
        {
            downTouchZ = true;
            if (isPlayerOnElevate || (!upTouchZ || !downTouchZ))
            {
                isRunningTargetPosition = true;
                isRunningBasePosition = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            else
            {
                isRunning = isPlayerOnElevate;
            }
        }
        
        if (isRunning)
            transform.Translate(transform.forward * elevatorSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnElevate = true;
            upTouchZ = false;
            downTouchZ = false;
            oldParent = other.gameObject.transform.parent;
            other.gameObject.transform.parent = transform;
            
            if (transform.position.z >= targetPositonZ)
            {
                isRunningBasePosition = true;
                isRunningTargetPosition = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.z <= BasePositonZ)
            {
                isRunningTargetPosition = true;
                isRunningBasePosition = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = oldParent;
            isPlayerOnElevate = false;
        }
    }
    
}