using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }


    #region Singleton
    public static ObjectPooler Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDic;




    void Start()
    {
        poolDic = new Dictionary<string, Queue<GameObject>>(); 
        foreach (Pool pool in pools) 
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDic.Add(pool.tag, objectPool);
        }
    }


    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDic.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with Tag" + tag + "doesnt excist");
            return null;
        }


        GameObject objectToSpawn = poolDic[tag].Dequeue();
        objectToSpawn.SetActive(true);
       //objectToSpawn.transform.position = position;
        //objectToSpawn.transform.rotation = rotation;

        IPooledObjects pooledObjects = objectToSpawn.GetComponent<IPooledObjects>();
        if (pooledObjects != null)
        {
            pooledObjects.OnObjectSpawn();
        }

        poolDic[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
