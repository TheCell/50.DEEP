using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour
{
    [SerializeField] private float offscreenDistance = 3;
    [SerializeField] private GameObject resourcePrefab;
    [SerializeField] private float spawnrate = 5;
    private float lastSpawnTime;
    private int iterator;
    private GameObject[] objectPool;

    private void Start()
    {
        lastSpawnTime = Time.time;
        objectPool = new GameObject[100];
    }

    private void Update()
    {
        if (Time.time > lastSpawnTime + (1 / spawnrate))
        {
            SpawnResourceOffscreen();
            lastSpawnTime = Time.time;
        }
    }

    private void SpawnResourceOffscreen()
    {
        GameObject resource = Instantiate(resourcePrefab);
        resource.transform.position = GetRandomPosition();
        ResourceLogic resourceLogic = resource.GetComponent<ResourceLogic>();
        resourceLogic.SetResourceType(GetRandomType());

        GameObject oldObj = GetNextPoolObject();
        Destroy(oldObj);
        objectPool[iterator] = resource;
    }

    private GameObject GetNextPoolObject()
    {
        GameObject obj = null;

        iterator++;
        if (iterator > objectPool.Length -1)
        {
            iterator = 0;
        }

        if (objectPool[iterator] != null)
        {
            obj = objectPool[iterator];
        }

        return obj;
    }

    private Vector3 GetRandomPosition()
    {
        float randomValueX = Random.Range(-1 * offscreenDistance - 2f, offscreenDistance + 2f);
        float randomValueY = Random.Range(-offscreenDistance, -offscreenDistance - 2f);

        Vector3 pos = new Vector3(randomValueX, randomValueY, 0);

        if (Vector3.Distance(pos, transform.position) < offscreenDistance)
        {
            if (Mathf.Abs(randomValueX) < offscreenDistance)
            {
                if (randomValueX > 0f)
                {
                    randomValueX += offscreenDistance;
                }
                else
                {
                    randomValueX -= offscreenDistance;
                }
            }
            if (Mathf.Abs(randomValueY) < offscreenDistance)
            {
                if (randomValueY > 0f)
                {
                    randomValueY += offscreenDistance;
                }
                else
                {
                    randomValueY -= offscreenDistance;
                }
            }

            pos.x = randomValueX;
            pos.y = randomValueY;
        }

        return pos;
    }

    private ResourceType GetRandomType()
    {
        return Thecelleu.Utilities.RandomEnumValue<ResourceType>();
    }
}
