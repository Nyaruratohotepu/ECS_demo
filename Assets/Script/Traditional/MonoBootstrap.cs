using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class MonoBootstrap : MonoBehaviour
{
    public int perfabCount;
    public GameObject perfab;
    // Use this for initialization
    void Start()
    {
        if (perfab)
        {
            for (int i = 0; i < perfabCount; i++)
            {
                GameObject newObject = Instantiate(perfab);
                perfab.transform.position = Random.insideUnitSphere * 100;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
