using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionPool : MonoBehaviour {

    public static ExplosionPool current;
    public GameObject poolObject;
    public int poolAmount = 5;
    public bool willGrow = true;

    List<GameObject> pool;
    //set current to pool to be called from pooler
    void Awake()
    {
        current = this;
    }

    // initialize pool
    void Start()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < poolAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(poolObject);
            obj.SetActive(false);
            pool.Add(obj);
        }

    }

    //get pool object and if willGrow is true then grow pool
    public GameObject getPoolObj()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(poolObject);
            pool.Add(obj);
            return obj;
        }
        return null;
    }
}
