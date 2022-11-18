using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float elevatorSpeed = 2f;
    private bool isRunning = false;
    public float distance = 6.6f;
    private bool opensDoor = true;
    private bool closingDoor = false;
    private float downPosition;
    private float upPosition;
    private bool closeDoor = false;

    void Start()
    {
        upPosition = transform.position.x + distance;
        downPosition = transform.position.x;
    }

    void FixedUpdate()
    {
        if (opensDoor && transform.position.x >= upPosition)
        {
            
            if (closeDoor)
            {
                elevatorSpeed = -elevatorSpeed;
                closingDoor = true;
                opensDoor = false;
                isRunning = true;
            }
            else 
            {
                isRunning = false;
            }
            
        }
        else if (closingDoor && transform.position.x <= downPosition)
        {
            closeDoor = false;
            isRunning = false;
        }

        if (isRunning)
        {
            Vector3 move = transform.right * elevatorSpeed * Time.deltaTime;
            transform.Translate(move);
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (transform.position.x >= upPosition)
            {
                closingDoor = true;
                opensDoor = false;
                elevatorSpeed = -elevatorSpeed;
            }
            else if (transform.position.x <= downPosition)
            {
                opensDoor = true;
                closingDoor = false;
                elevatorSpeed = Mathf.Abs(elevatorSpeed);
            }
            isRunning = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            closeDoor = true;
    }
}
