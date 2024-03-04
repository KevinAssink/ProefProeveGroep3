using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;



namespace WorldMovement
{
    public class WorldMovement : MonoBehaviour, IPooledObjects
    {
        //-------------------Public-------------------//

        //-------------------Private-------------------//


        //-------------------Functions-------------------//

       public void OnObjectSpawn()
        {

            transform.position += Vector3.left * Time.deltaTime;

        }

    }


}
