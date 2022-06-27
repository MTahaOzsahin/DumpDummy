using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurviveBoy.Concretes.Managers
{
    public class PlafromSpawner : MonoBehaviour
    {
        public static PlafromSpawner SharedInstance;
        public List<GameObject> pooledObjects;
        public List<GameObject> pooledObjects2;
        public GameObject objectToPool;
        public GameObject objectToPool2;
        public int amountToPool;

        [Header("Positions")]
        [SerializeField] float spaceBetweenPlatforms;
        [SerializeField] float spaceBetweenPlatforms2;

        void Awake()
        {
            SharedInstance = this;
        }

        IEnumerator Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }

            pooledObjects2 = new List<GameObject>();
            GameObject tmp2;
            for (int i = 0; i < amountToPool; i++)
            {
                tmp2 = Instantiate(objectToPool2);
                tmp2.SetActive(false);
                pooledObjects2.Add(tmp2);
            }

            PlatfromSpawnerCube1();
            PlatfromSpawnerCube2();

            yield break;
        }
        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }
        public GameObject GetPooledObject2()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!pooledObjects2[i].activeInHierarchy)
                {
                    return pooledObjects2[i];
                }
            }
            return null;
        }
        void PlatfromSpawnerCube1()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject tmp1 = pooledObjects[i];
                if (tmp1 != null)
                {
                    tmp1.transform.parent = this.transform;
                    tmp1.transform.position += new Vector3(Random.Range(-1.5f, 1.5f), -0f, 40f + spaceBetweenPlatforms *i);
                    tmp1.SetActive(true);
                }
            }
            
        }
        void PlatfromSpawnerCube2()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                GameObject tmp2 = pooledObjects2[i];
                if (tmp2 != null)
                {
                    tmp2.transform.parent = this.transform;
                    tmp2.transform.position += new Vector3(Random.Range(-2.5f,2.5f), -0f, 40f + spaceBetweenPlatforms2 * i);
                    tmp2.SetActive(true);
                }
            }

        }

    }
}
