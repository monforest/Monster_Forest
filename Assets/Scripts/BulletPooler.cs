using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooler : MonoBehaviour {


    public float fireTime;

    public GameObject pooledObject;  // from prefab

    public int pooledAmount = 20;

    private List<GameObject> pooledObjects;


    //void Start()
    //{
    //    InvokeRepeating("Fire", 1f, 1f);
    //}
    //void Fire()
    //{
    //    Instantiate(bullet, transform.position, Quaternion.identity);
    //}

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

       // InvokeRepeating("GetPooledObject", 1f, 1f);
    }


//    void GetPooledObject()
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        GameObject obj = Instantiate(pooledObject);
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }
}
