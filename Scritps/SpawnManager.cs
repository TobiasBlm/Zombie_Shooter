using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public Vector3[] spawnPos;
    //for InvokeRepeating
    private float spawnDelay = 10;
    private float spawnIntervall = 1.5f;
    //every level can have a different spawn rate
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        //setzt zum start vom level jeweils die spawn rate
        spawnIntervall = spawnIntervall / spawnRate;
        // spawnt Zombies von Start an, mit delay in bestimmtem Zeitintervall
        InvokeRepeating("SpawnZombie", spawnDelay, spawnIntervall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnZombie()
    {
        // generiert zufällige zahl um aus Array von Zombies zu wählen
        int zombieIndex = Random.Range(0, zombiePrefabs.Length);      
        //zufällige Zahl um aus Array von Positionen zu wählen
        int posIndex = Random.Range(0, spawnPos.Length);
        //instantiiert Prefab aus Array
        Instantiate(zombiePrefabs[zombieIndex], spawnPos[posIndex], zombiePrefabs[0].transform.rotation);
    }
    /*
    // deklariert spawn Positionen in Ecke
    private void Positionen()
    {
        Vector3 spawnPos0 = new Vector3(26, 1, 29);
        Vector3 spawnPos1 = new Vector3(25, 1, -27);
        Vector3 spawnPos2 = new Vector3(-8, 1, 25);
        Vector3 spawnPos3 = new Vector3(-7, 1, -35);
        spawnPos[0] = spawnPos0;
        spawnPos[1] = spawnPos1;
        spawnPos[2] = spawnPos2;
        spawnPos[3] = spawnPos3;
    } spawn positionen werden in den scenen fesftgelegt
    */
}
