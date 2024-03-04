using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TileGenerator : MonoBehaviour
{
    //-------------------Public-------------------//

    public GameObject TheTile;
    public Transform GenerationPoint;
    public float DistanceBetween;
    public ObjectPool TheWorldPool;

    //-------------------Private-------------------//

    private float _platformWidth;
    private Transform _roadPosition;


    // Start is called before the first frame update
    void Start()
    {

        _platformWidth = TheTile.GetComponent<BoxCollider>().size.z;
        GameObject newTile = TheWorldPool.GetPooledObject();
        newTile.transform.position = new Vector3(_platformWidth, 0, 0); 


    }

    // Update is called once per frame
    void Update()
    {
        GameObject newTile = TheWorldPool.GetPooledObject();
        if (transform.position.x < GenerationPoint.position.x + DistanceBetween)
        {
           Vector3 newPosition = newTile.transform.position + new Vector3(0, 0, 0);

            newTile.transform.position = transform.position;
            newTile.SetActive(true);
        }   

        if (transform.position.x > GenerationPoint.position.x)
        {
           transform.position = new Vector3(0,0,0);
        }

    }
}