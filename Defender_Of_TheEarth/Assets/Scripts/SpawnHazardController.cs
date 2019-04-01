using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHazardController : MonoBehaviour
{
    
    [Header("Hazard")]
    public GameObject Hazard;
    public float startSpawn;
    public float waitSpawnTime;
    public float nextWaveTime;
    public int indexHazard;
    public float diminuirTime;
    public bool waveOn;

    [Header("Limite Hazard")]
    public Vector3 spawnLimit;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.inicioJuego)
        {
            StartCoroutine(SpawnHazard());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator SpawnHazard()
    {
        yield return new WaitForSeconds(startSpawn);
        while (waveOn)
        {
            for (int i = 0; i < indexHazard; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnLimit.x, spawnLimit.x), spawnLimit.y, Random.Range(-spawnLimit.z, spawnLimit.z));
                Instantiate(Hazard, spawnPosition, Quaternion.identity);
                //no hace colision con su compañero xd
                Physics.IgnoreCollision(Hazard.GetComponent<Collider>(), Hazard.GetComponent<Collider>());
                yield return new WaitForSeconds(waitSpawnTime);
            }
            StartCoroutine(NextW());
        }

    }

    IEnumerator NextW()
    {
        yield return new WaitForSeconds(nextWaveTime);
        waitSpawnTime -= diminuirTime;
    }

}
