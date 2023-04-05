using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speed = 50;
    float mult = -360;

    void Update()
    {
        transform.Rotate(0, 0, mult*speed * Time.deltaTime);
    }
}
