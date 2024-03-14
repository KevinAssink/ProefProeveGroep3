using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
using StateMachineNameSpace;

namespace EnviromentSpawn
{
    public class EnviromentSpawner : MonoBehaviour
    {
        //--------------------Private--------------------//
        [SerializeField]
        private List<GameObject> _objectsToSpawn = new();
        private List<GameObject> _objectPool = new();
        private List<GameObject> _activeObjects = new();

        [SerializeField]
        private int _amountOfObjectsToSpawn;

        private float _timer;

        [SerializeField]
        private Vector2 _timeBetweenSpawns;

        [SerializeField]
        private Transform _parentTransform;
        [SerializeField]
        private Transform _leftSpawnTransform;
        [SerializeField]
        private Transform _rightSpawnTransform;

        private StateMachine _stateMachine;

        //--------------------Functions--------------------//
        private void Awake() => InstantiateObjectPool();

        private void Start() => _stateMachine = StateMachine.Instance;

        private void Update()
        {
            if (_stateMachine.CurrentState == StateMachineState.GAME)
            {
                _timer += Time.deltaTime;

                if (_timer >= Random.Range(_timeBetweenSpawns.x, _timeBetweenSpawns.y))
                {
                    SpawnEnviromentWave();
                    _timer = 0;
                }
            }
        }

        private void SpawnEnviromentWave()
        {
            int randomIndex = Random.Range(0, 2);

            for (int i = 0; i < 2; i++)
            {
                if(randomIndex == 1)
                {
                    switch (i)
                    {
                        case 0:
                            SpawnObject(_leftSpawnTransform);
                            break;
                        case 1:
                            SpawnObject(_rightSpawnTransform);
                            break;
                    }
                }
            }
        }

        private void InstantiateObjectPool()
        {
            foreach (GameObject obstacle in _objectsToSpawn)
            {
                for (int i = 0; i < _amountOfObjectsToSpawn; i++)
                {
                    GameObject instantiatedObject = Instantiate(obstacle, Vector3.zero, Quaternion.identity);
                    _objectPool.Add(instantiatedObject);
                    instantiatedObject.SetActive(false);
                }
            }

            foreach (GameObject pooledObject in _objectPool)
            {
                pooledObject.transform.SetParent(_parentTransform);
            }

            _objectPool.Shuffle();
        }

        private GameObject SpawnObject(Transform spawnTransform)
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

        private void DeSpawnObject(GameObject obstacle)
        {
            obstacle.SetActive(false);

            obstacle.transform.position = Vector3.zero;

            _activeObjects.Remove(obstacle);
            _objectPool.Add(obstacle);
        }
    }
}