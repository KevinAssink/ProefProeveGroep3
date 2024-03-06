using ObstacleSpawning;
using System.Collections;
using UnityEngine;

public class MovementTester : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void OnEnable()
    {
        StartCoroutine(DespawnSelf());
    }

    private void Update()
    {
        transform.position += Vector3.right * _speed * Time.deltaTime;    
    }

    private IEnumerator DespawnSelf()
    {
        yield return new WaitForSeconds(5);
        ObstacleRowManager.Instance.Rows.Remove(ObstacleRowManager.Instance.GetRowOfObject(gameObject));
        ObstacleSpawner.Instance.DeSpawnObstacle(gameObject);
    }
}
