using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public GameObject[] SpawnPrefab;
    public Transform[] sp;
    public float waittimeMin = 2;
    public float waittimeMax = 5;
    public bool spawn = true;

    public void setSpawnBool(bool _spn) { spawn = _spn; }

    public void setWaittimeMax(float wtm)
    { 
        waittimeMax = wtm;
    }

    private void Start()
    {
        randomSpawning();
    }

    void Update()
    {
        if (waittimeMax < waittimeMin+2)
        { 
            waittimeMax = waittimeMin+3;
        }
    }

    public void randomSpawning()
    {
        if (spawn)
        {
            Transform randomTransform = sp[Random.Range(0, sp.Length)];
            GameObject randomGameObject = SpawnPrefab[Random.Range(0, SpawnPrefab.Length)];
            Instantiate(randomGameObject, randomTransform.position, randomTransform.rotation);
            StartCoroutine(waitTime(Random.Range(waittimeMin, waittimeMax)));
        }

        else { Destroy(this.gameObject); }
    }

    IEnumerator waitTime(float _wt)
    { 
        yield return new WaitForSeconds(_wt);
        randomSpawning();
    }
}
