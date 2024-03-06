using System.Collections.Generic;
using UnityEngine;

namespace ObstacleSpawning
{
    public class ObstacleSpawner : SingletonBehaviour<ObstacleSpawner>
    {
        //--------------------Private--------------------//
        [SerializeField]
        private List<GameObject> _obstacleList = new();
        private List<GameObject> _objectPool = new();
        private List<GameObject> _activeObjects = new();

        [SerializeField]
        private Transform _obstacleParent;
        [SerializeField]
        private Transform _leftSpawnTransform;
        [SerializeField]
        private Transform _middleSpawnTransform;
        [SerializeField] 
        private Transform _rightSpawnTransform;

        [SerializeField]
        private int _obstacleAmount;

        //--------------------Functions--------------------//
        private void Awake()
        {
            InstantiateObjectPool();

            InvokeRepeating(nameof(SpawnObstacleRow), 0f, 2f);
        }

        private void InstantiateObjectPool()
        {
            foreach (GameObject obstacle in _obstacleList)
            {
                for (int i = 0; i < _obstacleAmount; i++)
                {
                    GameObject instantiatedObject = Instantiate(obstacle, Vector3.zero, Quaternion.identity);
                    _objectPool.Add(instantiatedObject);
                    instantiatedObject.SetActive(false);
                }
            }

            foreach (GameObject pooledObject in _objectPool)
            {
                pooledObject.transform.SetParent(_obstacleParent);
            }
        }

        private void SpawnObstacleRow()
        {
            Transform spawnTransform = null;
            for (int i = 0; i < 3; i++)
            {
                int randomInterger = Random.Range(0, 2);
                switch (i)
                {
                    case 0:
                        spawnTransform = _leftSpawnTransform;
                        break;
                    case 1:
                        spawnTransform = _middleSpawnTransform;
                        break;
                    case 2:
                        spawnTransform = _rightSpawnTransform;
                        break;
                }

                if(randomInterger == 1)
                {
                    SpawnObstacle(spawnTransform);
                }
            }
        }

        private void SpawnObstacle(Transform spawnTransform)
        {
            GameObject spawnedObstacle = _objectPool[0];
            spawnedObstacle.transform.position = spawnTransform.position;
            spawnedObstacle.SetActive(true);
            _objectPool.Remove(spawnedObstacle);
            _activeObjects.Add(spawnedObstacle);
        }

        public void DeSpawnObstacle(GameObject obstacle)
        {
            obstacle.SetActive(false);
            obstacle.transform.position = Vector3.zero;
            _activeObjects.Remove(obstacle);
            _objectPool.Add(obstacle);
        }
    }
}