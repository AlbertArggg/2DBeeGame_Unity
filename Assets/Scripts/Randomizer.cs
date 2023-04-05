using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    void Start()
    {
        int r = Random.Range(0,100);
        if (r > 50)
        {
            this.gameObject.GetComponentInChildren<Animator>().SetInteger("Rand", 0);
        }
        else
        {
            this.gameObject.GetComponentInChildren<Animator>().SetInteger("Rand", 1);
        }
    }
}
