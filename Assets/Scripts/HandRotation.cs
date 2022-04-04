using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotation : MonoBehaviour
{
    public float speed = 1f;

    void Update()
    {
        transform.RotateAround(transform.position, transform.up, Time.deltaTime * speed);
    }
}
