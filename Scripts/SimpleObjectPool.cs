using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SimpleObjectPool : MonoBehaviour {

    public GameObject prefab;
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if(inactiveInstances.Count > 0)
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);
            PoolObject pooledObject = spawnedGameObject.AddComponent<PoolObject>();
            pooledObject.Pool = this;

            spawnedGameObject.transform.SetParent(null);
            spawnedGameObject.SetActive(true);




        }
        return spawnedGameObject;
    }
    public void ReturnObject(GameObject toReturn)
    {
        PoolObject pooledObject = toReturn.GetComponent<PoolObject>();
        if (pooledObject != null && pooledObject == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);
        }
        else
        {
            Debug.LogWarning(toReturn.name + "Was returned to a pool it wasn't spawned from! Destroying.");
            Destroy(toReturn);
        }
    }

}
public class PoolObject : MonoBehaviour
{
    public SimpleObjectPool Pool;
}