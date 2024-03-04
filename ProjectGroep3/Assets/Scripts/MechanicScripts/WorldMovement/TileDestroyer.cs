using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileDestroyer : MonoBehaviour
{
    //-------------------Public-------------------//

    public GameObject TileDestructionPoint;


    //-------------------Functions-------------------//

    private void Start()
    {
        TileDestructionPoint = GameObject.Find("DestructionPoint");
    }


    private void Update()
    {
        if (transform.position.x < TileDestructionPoint.transform.position.x && CompareTag("Road"))
        { 
            gameObject.SetActive(false);
        }
    }


}