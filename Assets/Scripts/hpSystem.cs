using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hpSystem : MonoBehaviour
{
    public GameObject[] HpSprites;
    public GameObject beeFlySprite;
    public GameObject beeDieSprite;
    public GameObject manager; 
    public AudioSource beeBuzzing;
    public AudioSource sdfx;
    public AudioClip hurt;
    public AudioClip dead;

    public bool takeDam = true;
    int hp = 3;

    void Start()
    {
        for (int i = 0; i < HpSprites.Length; i++) { HpSprites[i].SetActive(true); }
        manager = GameObject.FindGameObjectWithTag("GameTracker");
        if (manager.GetComponent<GaneTracker>().getMusicVol() <0.1) { beeBuzzing.volume = manager.GetComponent<GaneTracker>().getsdfxVol(); }
        else { beeBuzzing.volume = 0; }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Obs>() != null)
        {
            if(takeDam)
                TakeDamage();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var pickup = collision.gameObject.GetComponent<Pickup>();
        if (pickup != null)
        {
            if (pickup.type == "hp")
            {
                getHealth();
            }
            if (pickup.type == "Diamond")
            {
                addCurrency();
            }
            GameObject.Destroy(collision.gameObject);
        }
    }

    public void addCurrency()
    {
        manager.GetComponent<GaneTracker>().diamonds += 1;
    }

    public void getHealth()
    {
        if (hp>0 && hp<3)
        {
            Debug.Log(HpSprites[hp].name);
            HpSprites[hp].SetActive(true);
            HpSprites[hp].GetComponent<Animator>().SetTrigger("add");
            hp++;
        }
    }

    public void TakeDamage()
    {
        takeDam = false;
        beeFlySprite.GetComponent<Animator>().SetTrigger("dam");
        hp--;
        HpSprites[hp].GetComponent<triggerRemoveSprite>().playAnim();
        if (hp == 0) { die(); }
        else 
        {
            float vol = manager.GetComponent<GaneTracker>().getsdfxVol();
            sdfx.PlayOneShot(hurt,vol); 
        }
    }

    public void enableCol()
    {
        takeDam = true;
    }

    public void die()
    {
        float vol = manager.GetComponent<GaneTracker>().getsdfxVol();
        sdfx.PlayOneShot(dead,vol);
        beeFlySprite.SetActive(false);
        beeDieSprite.SetActive(true);
        this.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        GameObject.FindGameObjectWithTag("GameTracker").GetComponent<GaneTracker>().setPlayerBool();
        StartCoroutine(waitAndDie());
    }

    IEnumerator waitAndDie()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
