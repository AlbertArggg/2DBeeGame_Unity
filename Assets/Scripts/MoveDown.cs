using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public bool constSpeed;
    public float travelSpeed;
    public float travelSpeedMin;
    public float travelSpeedMax;
    public bool playerDead = false;

    public void setPlayerDeadBool()
    { 
        playerDead = true;
    }

    void Update()
    {
        if (!playerDead)
        {
            if (constSpeed)
                transform.Translate(Vector3.down * travelSpeed * Time.deltaTime, Space.World);
            else
                transform.Translate(Vector3.down * Random.Range
                    (travelSpeedMin, travelSpeedMax) * Time.deltaTime, Space.World);
        }
    }
}
