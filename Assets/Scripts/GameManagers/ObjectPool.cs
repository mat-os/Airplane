using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviourSingleton<ObjectPool>
{
    // The objects to pool.
    [SerializeField]private GameObject[] objects;

    // The list of pooled objects.
    private List<GameObject>[] pooledObjects;

    // The amount of objects to buffer.
    [SerializeField]private int[] amountToBuffer;

    [SerializeField]private int defaultBufferAmount;

    // The container of pooled objects.
    protected GameObject containerObject;

    private void Start()
    {
        containerObject = new GameObject("ObjectPool");
        pooledObjects = new List<GameObject>[objects.Length];

        var i = 0;
        foreach (var obj in objects)
        {
            pooledObjects[i] = new List<GameObject>();

            int bufferAmount;

            if (i < amountToBuffer.Length)
                bufferAmount = amountToBuffer[i];
            else
                bufferAmount = defaultBufferAmount;

            for (var n = 0; n < bufferAmount; n++)
            {
                var newObj = Instantiate(obj);
                newObj.name = obj.name;
                PoolObject(newObj);
            }

            i++;
        }
    }

    // Pull an object of a specific type from the pool.
    public GameObject PullObject(string objectType)
    {
        var onlyPooled = false;
        for (var i = 0; i < objects.Length; i++)
        {
            var prefab = objects[i];

            if (prefab.name == objectType)
            {
                if (pooledObjects[i].Count > 0)
                {
                    var pooledObject = pooledObjects[i][0];
                    pooledObject.SetActive(true);
                    pooledObject.transform.parent = null;

                    pooledObjects[i].Remove(pooledObject);

                    return pooledObject;
                }

                if (!onlyPooled) return Instantiate(objects[i]);

                break;
            }
        }

        // Null if there's a hit miss.
        return null;
    }

    // Add object of a specific type to the pool.
    public void PoolObject(GameObject obj)
    {
        for (var i = 0; i < objects.Length; i++)
            if (objects[i].name == obj.name)
            {
                obj.SetActive(false);
                obj.transform.parent = containerObject.transform;
                pooledObjects[i].Add(obj);
                return;
            }

        Destroy(obj);
    }
}