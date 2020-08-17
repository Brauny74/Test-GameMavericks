using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler : MonoBehaviour
{
    public int PoolSize;
    public GameObject poolElementPrefab;
    List<GameObject> pool;

    public void Start()
    {
        GameObject tempObj;
        pool = new List<GameObject>();
        for (int i = 0; i < PoolSize; i++)
        {
            tempObj = Instantiate(poolElementPrefab);
            tempObj.SetActive(false);
            pool.Add(tempObj);
        }
    }

    public GameObject GetLastInactive()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }
        PoolSize++;
        GameObject tempObj;
        tempObj = Instantiate(poolElementPrefab);
        tempObj.SetActive(false);
        pool.Add(tempObj);
        return tempObj;
    }
    
}
