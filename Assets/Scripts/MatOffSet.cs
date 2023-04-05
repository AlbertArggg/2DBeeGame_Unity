using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatOffSet : MonoBehaviour
{
    public float scrollSpeed = 0.05f;
    Renderer rend;
    bool playerDead = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void setPlayerBool()
    {
        playerDead = true;
    }

    void Update()
    {
        if (!playerDead)
        {
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
        }
    }
}
