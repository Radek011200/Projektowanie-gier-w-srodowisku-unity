using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class RandomCubesGenerator : MonoBehaviour
{

    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    public int numberOfBlocks;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    private Object[] materials;
    void Start()
    {
        Transform plane = gameObject.GetComponent<Transform>();

        materials = (Resources.LoadAll("Kolory", typeof(Material)));


        // w momecie uruchomienia generuje 10 kostek w losowych miejscach

        // alternatywnie mo¿na skorzystaæ z renderer bounds
        List<int> pozycje_x = new List<int>(Enumerable.Range((int)(plane.position.x -(plane.localScale.x * 5)), (int)(plane.position.x + (plane.localScale.x * 5))).OrderBy(x => Guid.NewGuid()).Take(10));
        List<int> pozycje_z = new List<int>(Enumerable.Range((int)(plane.position.z - (plane.localScale.z * 5)), (int)(plane.position.z + (plane.localScale.z * 5))).OrderBy(x => Guid.NewGuid()).Take(10));

        for (int i = 0; i < numberOfBlocks; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        Debug.Log("Tu");
        Debug.Log(gameObject.GetComponent<Transform>().localScale.x);
        Debug.Log(gameObject.GetComponent<Transform>().position.z);
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            Material material = (Material)materials[Random.Range(0, materials.Length)];

            this.block.GetComponent<Renderer>().material = material;
            Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }

}