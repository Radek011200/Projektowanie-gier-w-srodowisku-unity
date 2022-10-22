using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad6 : MonoBehaviour
{
    public Transform target;
    float smoothTime = 0.3f;
    float yVelocity = 0.0f;

    public float minimum = -1.0F;
    public float maximum = 1.0F;

    // starting value for the Lerp
    static float t = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
        // float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y, ref yVelocity, smoothTime);
        // transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);


        // Czêœæ druga zadania z Mathf.Lerp
        // animate the position of the game object...
        transform.position = new Vector3(Mathf.Lerp(minimum, maximum, t), 0, 0);

        // .. and increase the t interpolater
        t += 0.5f * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
