using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    
    public float spawnTime = 3f;           
    public Transform[] spawnPoints;       

    //Call Spawn method to spawn enemies randomly
    void Start()
    {        
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    //randomly choose spawn point and then activate enemy at that location
    void Spawn()
    {        
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);    
        GameObject obj = EnemyPool.current.getPoolObj();
        if (obj == null) return;
        obj.transform.position = spawnPoints[spawnPointIndex].position;
        obj.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        obj.SetActive(true);       
    }
}
