using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using Unity.Transforms;

public class RotateSelf : MonoBehaviour
{
    public float rotateSpeed = 10;
    private Transform transform;
    // Use this for initialization
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = math.mul(math.normalize(transform.rotation), quaternion.AxisAngle(math.up(), rotateSpeed * Time.deltaTime));
    }
}
