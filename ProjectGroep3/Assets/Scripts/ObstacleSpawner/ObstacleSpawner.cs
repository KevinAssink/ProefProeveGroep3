using System.Collections.Generic;
using UnityEngine;
using Utilities;

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
        private int _obstacleAmount;

        [SerializeField]
        private float _timeBetweenSpawns;

        [SerializeField]
        private Transform _obstacleParent;
        [SerializeField]
        private Transform _leftSpawnTransform;
        [SerializeField]
        private Transform _middleSpawnTransform;
        [SerializeField] 
        private Transform _rightSpawnTransform;

        private ObstacleRowManager _rowManager;

        //--------------------Functions--------------------//
        private void Awake()
        {
            InstantiateObjectPool();

            InvokeRepeating(nameof(SpawnObstacleRow), 0f, _timeBetweenSpawns);
        }

        private void Start() => _rowManager = ObstacleRowManager.Instance;

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

            _objectPool.Shuffle();
        }

        private void SpawnObstacleRow()
        {
            Transform spawnTransform = null;
            List<GameObject> spawnedObjects = new();

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
                    spawnedObjects.Add(SpawnObstacle(spawnTransform));
                }
            }

            if(spawnedObjects.Count == 3 || spawnedObjects.Count == 0) 
            {
                foreach (GameObject spawnedObject in spawnedObjects)
                {
                    DeSpawnObstacle(spawnedObject);
                }

                SpawnObstacleRow();
            }
            else
            {
                _rowManager.Rows.Add(spawnedObjects);
            }
        }

        private GameObject SpawnObstacle(Transform spawnTransform)
        {
            if (_objectPool.Count == 0)
                return null;

            GameObject spawnedObstacle = _objectPool[0];
            spawnedObstacle.transform.position = spawnTransform.position;
            spawnedObstacle.SetActive(true);
            _objectPool.Remove(spawnedObstacle);
            _activeObjects.Add(spawnedObstacle);

            return spawnedObstacle;
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