using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zad5 : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10.0f, 10.0f), 5, Random.Range(-10.0f, 10.0f));
            Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
