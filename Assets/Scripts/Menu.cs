using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sdfx;
    public AudioClip playClip;
    public AudioClip menuSwitch;
    public AudioClip pos;
    public AudioClip neg;
    public AudioClip err;

    public Animator anim;

    public TMP_Text txtMusicVol;
    public TMP_Text txtGameMusicVol;
    public TMP_Text txtsdfxVol;
    public TMP_Text txtsensVol;
    public TMP_Text txtDonVol;
    public TMP_Text txtDiamonds;

    public GameObject[] musicVolVis;
    public GameObject[] gameMusicVolVis;
    public GameObject[] sdfxVolVis;
    public GameObject[] sensitivityVis;
    public GameObject[] donateVis;
    public GameObject[] donButns;
    public GameObject[] CustomItems;

    int musicVol = 80;
    int gameMusicVol = 50;
    int sdfxVol = 80;
    int sensitivity = 60;
    int don = 3;
    int hs;
    int dim;
    int itm;

    public int getDon()
    {
        return don;
    }
    public void Start()
    {
        for (int i = 0; i < donButns.Length; i++)
        {
            donButns[i].gameObject.SetActive(false);
        }
        donButns[don - 1].gameObject.SetActive(true);
        GetPlayerDataFromFile();
        ApplyVisualUIFromData();
        PopulateTextFieldsFromData();
        setUIColor(1);
        setUIColor(2);
        setUIColor(3);
        setUIColor(4);
        txtDiamonds.text = dim.ToString();
    }
    private void PopulateTextFieldsFromData()
    {
        string str = musicVol.ToString() + "%";
        txtMusicVol.SetText(str);
        str = gameMusicVol.ToString() + "%";
        txtGameMusicVol.SetText(str);
        str = sdfxVol.ToString() + "%";
        txtsdfxVol.SetText(str);
        str = sensitivity.ToString() + "%";
        txtsensVol.SetText(str);
        str = "$" + don.ToString();
        txtDonVol.SetText(str);
    }
    private void ApplyVisualUIFromData()
    {
        for (int i = 0; i < 10; i++)
        {
            if ((i * 10) < musicVol) { musicVolVis[i].SetActive(true); }
            else { musicVolVis[i].SetActive(false); }

            if ((i * 10) < gameMusicVol) { gameMusicVolVis[i].SetActive(true); }
            else { gameMusicVolVis[i].SetActive(false); }

            if ((i * 10) < sdfxVol) { sdfxVolVis[i].SetActive(true); }
            else { sdfxVolVis[i].SetActive(false); }

            if ((i * 10) < sensitivity) { sensitivityVis[i].SetActive(true); }
            else { sensitivityVis[i].SetActive(false); }

            if (i < don) { donateVis[i].SetActive(true); }
            else { donateVis[i].SetActive(false); }
        }
    }
    public void setUIColor(int modVis)
    {
        Color green = new Color32(158,255,81,255);
        Color yellow = new Color32(255,103,45,255);
        Color red = new Color32(255,88,82,255);

        if (modVis == 1)
        {
            for (int i = 0; i < musicVolVis.Length; i++)
            {
                if (musicVolVis[i] != null) 
                {
                    if (musicVol > 70) { musicVolVis[i].GetComponent<Image>().color = green; }
                    else if (musicVol > 30) { musicVolVis[i].GetComponent<Image>().color = green; }
                    else { musicVolVis[i].GetComponent<Image>().color = green; }
                } 
            }
        }
        else if (modVis == 2)
        {
            for (int i = 0; i < gameMusicVolVis.Length; i++)
            {
                if (gameMusicVolVis[i] != null)
                {
                    if (gameMusicVol > 70) { gameMusicVolVis[i].GetComponent<Image>().color = green; }
                    else if (gameMusicVol > 30) { gameMusicVolVis[i].GetComponent<Image>().color = green; }
                    else { gameMusicVolVis[i].GetComponent<Image>().color = green; }
                }
            }
        }
        else if (modVis == 3)
        {
            for (int i = 0; i < sdfxVolVis.Length; i++)
            {
                if (sdfxVolVis[i] != null)
                {
                    if (sdfxVol > 70) { sdfxVolVis[i].GetComponent<Image>().color = green; }
                    else if (sdfxVol > 30) { sdfxVolVis[i].GetComponent<Image>().color = green; }
                    else { sdfxVolVis[i].GetComponent<Image>().color = green; }
                }
            }
        }
        else
        {
            for (int i = 0; i < sensitivityVis.Length; i++)
            {
                if (sensitivityVis[i] != null)
                {
                    if (sensitivity > 70) { sensitivityVis[i].GetComponent<Image>().color = green; }
                    else if (sensitivity > 30) { sensitivityVis[i].GetComponent<Image>().color = green; }
                    else { sensitivityVis[i].GetComponent<Image>().color = green; }
                }
            }
        }
    }
    private void GetPlayerDataFromFile()
    {
        PlayerData d = SaveAndLoadSystem.loadData();
        musicVol = d.musicVol;
        gameMusicVol = d.gameMusicVol;
        sdfxVol = d.sdfxVol;
        sensitivity = d.sensitivity;
        hs = d.highScore;
        dim = d.diamonds;
        itm = d.custItem;

        float mvol = (float)musicVol;
        music.volume = mvol / 100;
        float sdvol = (float)sdfxVol;
        sdfx.volume = sdvol / 100;
    }
    public void updateVals()
    {
        float mvol = (float)musicVol;
        music.volume = mvol / 100;
        float sdvol = (float)sdfxVol;
        sdfx.volume = sdvol / 100;
    }
    public void switchMenus(int from, int to)
    {
        if (from == 0 && to == 1) { anim.SetTrigger("toSet"); }         // go to settings
        else if (from == 0 && to == -1) { anim.SetTrigger("toDon"); }   // go to donate
        else if (from == 0 && to == 2) { anim.SetTrigger("toCust"); } // go to Customize
        else if (from == 1) { anim.SetTrigger("toMfromS"); }            // go to menu from settings
        else if (from == -1) { anim.SetTrigger("toMfromD"); }           // go to menu from don
        else if (from == 2) { anim.SetTrigger("toMfromC"); }           // go to menu from don
        sdfx.PlayOneShot(menuSwitch);
    }
    public void play()
    {
        switchMenus(0, 2);
    }
    public void settings() { switchMenus(0, 1); }
    public void donate() { switchMenus(0, -1); }
    public void toMenuFromDon() { switchMenus(-1, 0); }
    public void toMenuFromSet() { switchMenus(1, 0); }
    public void toMenuFromCust() { switchMenus(2, 0); }
    public void musicPb() 
    {
        if (musicVol <= 90)
        {
            musicVol += 10;
            musicVolVis[(musicVol / 10) - 1].gameObject.SetActive(true);
            string str = musicVol.ToString() + "%";
            txtMusicVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(pos);
            setUIColor(1);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void musicNb() 
    {
        if (musicVol >= 10)
        {
            musicVolVis[(musicVol / 10)-1].gameObject.SetActive(false);
            musicVol -= 10;
            string str = musicVol.ToString() + "%";
            txtMusicVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(neg);
            setUIColor(1);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void musicGamePb()
    {
        if (gameMusicVol <= 90)
        {
            gameMusicVol += 10;
            gameMusicVolVis[(gameMusicVol / 10) - 1].gameObject.SetActive(true);
            string str = gameMusicVol.ToString() + "%";
            txtGameMusicVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(pos);
            setUIColor(2);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void musicGameNb()
    {
        if (gameMusicVol >= 10)
        {
            gameMusicVolVis[(gameMusicVol / 10) - 1].gameObject.SetActive(false);
            gameMusicVol -= 10;
            string str = gameMusicVol.ToString() + "%";
            txtGameMusicVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(neg);
            setUIColor(2);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void sdfxPb()
    {
        if (sdfxVol <= 90)
        {
            sdfxVol += 10;
            sdfxVolVis[(sdfxVol / 10)-1].gameObject.SetActive(true);
            string str = sdfxVol.ToString() + "%";
            txtsdfxVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(pos);
            setUIColor(3);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void sdfxNb()
    {
        if (sdfxVol >= 10)
        {
            sdfxVolVis[(sdfxVol / 10)-1].gameObject.SetActive(false);
            sdfxVol -= 10;
            string str = sdfxVol.ToString() + "%";
            txtsdfxVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(neg);
            setUIColor(3);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void sensPb()
    {
        if (sensitivity <= 90)
        {
            sensitivity += 10;
            sensitivityVis[(sensitivity / 10)-1].gameObject.SetActive(true);
            string str = sensitivity.ToString() + "%";
            txtsensVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(pos);
            setUIColor(4);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void sensNb()
    {
        if (sensitivity >= 20)
        {
            sensitivityVis[(sensitivity / 10)-1].gameObject.SetActive(false);
            sensitivity -= 10;
            string str = sensitivity.ToString() + "%";
            txtsensVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(neg);
            setUIColor(4);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void donPb()
    {
        if (don <= 9)
        {
            don++;
            donateVis[don-1].gameObject.SetActive(true);
            for (int i = 0; i < donButns.Length; i++)
            {
                donButns[i].gameObject.SetActive(false);
            }
            donButns[don-1].gameObject.SetActive(true);
            string str = "$" + don.ToString();
            txtDonVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(pos);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void donNb()
    {
        if (don >= 2)
        {
            donateVis[don-1].gameObject.SetActive(false);
            don--;

            for (int i = 0; i < donButns.Length; i++)
            {
                donButns[i].gameObject.SetActive(false);
            }
            donButns[don - 1].gameObject.SetActive(true);

            string str = "$" + don.ToString();
            txtDonVol.SetText(str);
            updateVals();
            sdfx.PlayOneShot(neg);
            SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        }
        else { sdfx.PlayOneShot(err); }
    }
    public void level1()
    {
        Debug.Log("Play");
        sdfx.PlayOneShot(playClip);
        music.volume = 0;
        SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        StartCoroutine(waitAndLoad(1));
    }
    public void level2()
    {
        Debug.Log("Play");
        sdfx.PlayOneShot(playClip);
        music.volume = 0;
        SaveAndLoadSystem.saveData(musicVol, gameMusicVol, sdfxVol, sensitivity, hs, dim, itm);
        StartCoroutine(waitAndLoad(2));
    }
    IEnumerator waitAndLoad(int scene)
    {
        yield return new WaitForSecondsRealtime(1);
        SceneManager.LoadScene("GameScene"+scene);
    }
}
