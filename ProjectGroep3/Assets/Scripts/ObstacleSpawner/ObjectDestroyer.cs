using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EnviromentSpawn;
using ObstacleSpawning;

namespace ObstacleHit
{
    public class ObjectDestroyer : MonoBehaviour
    {
        //----------------------Private----------------------//
        private EnviromentSpawner _environmentSpawner;
        private ObstacleSpawner _obstacleSpawner;

        //----------------------Functions----------------------//
        private void Start()
        {
            _environmentSpawner = EnviromentSpawner.Instance;
            _obstacleSpawner = ObstacleSpawner.Instance;
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Obstacle")) 
            {
                _obstacleSpawner.DeSpawnObstacle(other.gameObject);
            }
            else if (other.CompareTag("Environment"))
            {
                _environmentSpawner.DeSpawnObject(other.gameObject);
            }
        }
    }
}