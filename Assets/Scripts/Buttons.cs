using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public AudioSource sdfx;
    public AudioClip playClip;
    public AudioClip settingsClip;
    public AudioClip donateClip;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            play();

        if (Input.GetKeyDown(KeyCode.W))
            settings();

        if (Input.GetKeyDown(KeyCode.E))
            donate();
    }

    public void play()
    {
        Debug.Log("Play");
        sdfx.PlayOneShot(playClip);
    }
    public void settings()
    {
        Debug.Log("Settings");
        sdfx.PlayOneShot(settingsClip);
    }
    public void donate()
    {
        Debug.Log("donate");
        sdfx.PlayOneShot(donateClip);
    }
    public void menu()
    { 
    
    }
}

