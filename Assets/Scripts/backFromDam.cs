using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backFromDam : MonoBehaviour
{
    public void reEnableCol()
    {
        this.gameObject.GetComponentInParent<hpSystem>().enableCol();
    }
}
