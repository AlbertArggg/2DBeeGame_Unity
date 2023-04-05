using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerRemoveSprite : MonoBehaviour
{
    public void playAnim()
    {
        this.gameObject.GetComponent<Animator>().SetTrigger("remove");
    }

    public void removeHp()
    { 
        this.gameObject.SetActive(false);
    }
}
