using ObstacleSpawning;
using UnityEngine;

public class MovementTester : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Start()
    {
        Invoke(nameof(DespawnSelf), 5f);
    }

    private void Update()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;    
    }

    private void DespawnSelf()
    {
        ObstacleSpawner.Instance.DeSpawnObstacle(gameObject);
    }
}
