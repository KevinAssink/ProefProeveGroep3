using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnerV2 : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Road", transform.position, Quaternion.identity);
    }
}