using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioAxe : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip swing;
    public AudioClip slam;
    GameObject manager;
    public void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameTracker");
    }
    public void playSwing()
    {
        float vol = manager.GetComponent<GaneTracker>().getsdfxVol();
        audio.PlayOneShot(swing, vol/3);
    }

    public void playSlam()
    {
        float vol = manager.GetComponent<GaneTracker>().getsdfxVol();
        audio.PlayOneShot(slam, vol); ;
    }
}
